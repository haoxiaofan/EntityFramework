// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.TestModels.TransportationModel;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable InconsistentNaming
namespace Microsoft.EntityFrameworkCore
{
    public abstract class TableSplittingTestBase
    {
        protected TableSplittingTestBase(ITestOutputHelper testOutputHelper)
        {
            TestOutputHelper = testOutputHelper;
        }

        [Fact]
        public virtual void Can_query_shared()
        {
            using (CreateTestStore(OnModelCreating))
            {
                using (var context = CreateContext())
                {
                    Assert.Equal(5, context.Set<Operator>().ToList().Count);
                }
            }
        }

        [Fact]
        public virtual void Can_query_shared_derived_hierarchy()
        {
            using (CreateTestStore(OnModelCreating))
            {
                using (var context = CreateContext())
                {
                    Assert.Equal(2, context.Set<FuelTank>().ToList().Count);
                }
            }
        }

        [Fact]
        public virtual void Can_query_shared_derived_nonhierarchy()
        {
            using (CreateTestStore(modelBuilder =>
            {
                OnModelCreating(modelBuilder);
                modelBuilder.Ignore<SolidFuelTank>();
            }))
            {
                using (var context = CreateContext())
                {
                    Assert.Equal(2, context.Set<FuelTank>().ToList().Count);
                }
            }
        }

        [Fact]
        public virtual void Can_use_with_redundant_relationships()
        {
            Test_roundtrip(OnModelCreating);
        }

        // #9005
        // [Fact]
        public virtual void Can_use_with_chained_relationships()
        {
            Test_roundtrip(
                modelBuilder =>
                    {
                        OnModelCreating(modelBuilder);
                        //modelBuilder.Entity<FuelTank>(eb => { eb.Ignore(e => e.Vehicle); });
                    });
        }

        // #9005
        // [Fact]
        public virtual void Can_use_with_fanned_relationships()
        {
            Test_roundtrip(
                modelBuilder =>
                    {
                        OnModelCreating(modelBuilder);
                        modelBuilder.Entity<FuelTank>(eb => { eb.Ignore(e => e.Engine); });
                        modelBuilder.Entity<CombustionEngine>(eb => { eb.Ignore(e => e.FuelTank); });
                    });
        }

        protected void Test_roundtrip(Action<ModelBuilder> onModelCreating)
        {
            using (CreateTestStore(onModelCreating))
            {
                using (var context = CreateContext())
                {
                    context.AssertSeeded();
                }
            }
        }

        [Fact]
        public virtual void Inserting_dependent_with_just_one_parent_throws()
        {
            using (CreateTestStore(OnModelCreating))
            {
                using (var context = CreateContext())
                {
                    context.Add(new PoweredVehicle
                    {
                        Name = "Fuel transport",
                        SeatingCapacity = 1,
                        Operator = new LicensedOperator { Name = "Jack Jackson", LicenseType = "Class A CDC" }
                    });
                    context.Add(new FuelTank
                    {
                        Capacity = "10000 l",
                        FuelType = "Gas",
                        VehicleName = "Fuel transport"
                    });

                    Assert.Equal(RelationalStrings.SharedRowEntryCountMismatchSensitive(
                        nameof(PoweredVehicle), "Vehicles", nameof(Engine), "{Name: Fuel transport}", "Added"),
                        Assert.Throws<InvalidOperationException>(() => context.SaveChanges()).Message);
                }
            }
        }

        [Fact]
        public virtual void Can_change_dependent_instance_non_derived()
        {
            using (CreateTestStore(
                modelBuilder =>
                    {
                        OnModelCreating(modelBuilder);
                        modelBuilder.Entity<Engine>().ToTable("Engines");
                        modelBuilder.Entity<FuelTank>(
                            eb =>
                                {
                                    eb.ToTable("FuelTanks");
                                    eb.HasOne(e => e.Engine)
                                        .WithOne(e => e.FuelTank)
                                        .HasForeignKey<FuelTank>(e => e.VehicleName)
                                        .OnDelete(DeleteBehavior.Restrict);
                                });
                        modelBuilder.Ignore<SolidFuelTank>();
                        modelBuilder.Ignore<SolidRocket>();
                    }))
            {
                using (var context = CreateContext())
                {
                    var bike = context.Vehicles.Include(v => v.Operator).Single(v => v.Name == "Trek Pro Fit Madone 6 Series");

                    bike.Operator = new Operator { Name = "Chris Horner" };

                    context.ChangeTracker.DetectChanges();

                    bike.Operator = new LicensedOperator { Name = "repairman", LicenseType = "Repair" };

                    TestSqlLoggerFactory.Clear();
                    context.SaveChanges();
                }

                using (var context = CreateContext())
                {
                    var bike = context.Vehicles.Include(v => v.Operator).Single(v => v.Name == "Trek Pro Fit Madone 6 Series");
                    Assert.Equal("repairman", bike.Operator.Name);

                    Assert.Equal("Repair", ((LicensedOperator)bike.Operator).LicenseType);
                }
            }
        }

        [Fact]
        public virtual void Can_change_principal_instance_non_derived()
        {
            using (CreateTestStore(
                modelBuilder =>
                    {
                        OnModelCreating(modelBuilder);
                        modelBuilder.Entity<Engine>().ToTable("Engines");
                        modelBuilder.Entity<FuelTank>(
                            eb =>
                                {
                                    eb.ToTable("FuelTanks");
                                    eb.HasOne(e => e.Engine)
                                        .WithOne(e => e.FuelTank)
                                        .HasForeignKey<FuelTank>(e => e.VehicleName)
                                        .OnDelete(DeleteBehavior.Restrict);
                                });
                        modelBuilder.Ignore<SolidFuelTank>();
                        modelBuilder.Ignore<SolidRocket>();
                    }))
            {
                using (var context = CreateContext())
                {
                    var bike = context.Vehicles.Single(v => v.Name == "Trek Pro Fit Madone 6 Series");

                    var newBike = new Vehicle { Name = "Trek Pro Fit Madone 6 Series", Operator = bike.Operator, SeatingCapacity = 2 };

                    context.Remove(bike);
                    context.Add(newBike);

                    TestSqlLoggerFactory.Clear();
                    context.SaveChanges();
                }

                using (var context = CreateContext())
                {
                    var bike = context.Vehicles.Include(v => v.Operator).Single(v => v.Name == "Trek Pro Fit Madone 6 Series");

                    Assert.Equal(2, bike.SeatingCapacity);
                    Assert.NotNull(bike.Operator);
                }
            }
        }

        protected readonly string DatabaseName = "TableSplittingTest";
        protected TestStore TestStore { get; set; }
        protected abstract ITestStoreFactory TestStoreFactory { get; }
        protected IServiceProvider ServiceProvider { get; set; }
        protected TestSqlLoggerFactory TestSqlLoggerFactory => (TestSqlLoggerFactory)ServiceProvider.GetRequiredService<ILoggerFactory>();
        protected ITestOutputHelper TestOutputHelper { get; }

        protected void AssertSql(params string[] expected)
            => TestSqlLoggerFactory.AssertBaseline(expected);
        protected void AssertContainsSql(params string[] expected)
            => TestSqlLoggerFactory.AssertBaseline(expected, assertOrder: false);

        protected virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(
                eb =>
                    {
                        eb.HasDiscriminator<string>("Discriminator");
                        eb.Property<string>("Discriminator").HasColumnName("Discriminator");
                        eb.ToTable("Vehicles");
                    });

            modelBuilder.Entity<Engine>().ToTable("Vehicles");
            modelBuilder.Entity<Operator>().ToTable("Vehicles");
            modelBuilder.Entity<FuelTank>().ToTable("Vehicles");
        }

        protected TestStore CreateTestStore(Action<ModelBuilder> onModelCreating)
        {
            TestStore = TestStoreFactory.Create(DatabaseName);

            ServiceProvider = TestStoreFactory.AddProviderServices(new ServiceCollection())
                .AddSingleton(TestModelSource.GetFactory(onModelCreating))
                .BuildServiceProvider(validateScopes: true);

            TestStore.Initialize(ServiceProvider, CreateContext, c => ((TransportationContext)c).Seed());

            TestSqlLoggerFactory.Clear();

            // To enable logging
            //TestSqlLoggerFactory.SetTestOutputHelper(TestOutputHelper);

            return TestStore;
        }

        protected virtual DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            => builder
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(
                    b => b.Default(WarningBehavior.Throw)
                        .Log(CoreEventId.SensitiveDataLoggingEnabledWarning)
                        .Log(CoreEventId.PossibleUnintendedReferenceComparisonWarning));

        protected virtual TransportationContext CreateContext()
        {
            var options = AddOptions(TestStore.AddProviderOptions(new DbContextOptionsBuilder()))
                .UseInternalServiceProvider(ServiceProvider).Options;
            return new TransportationContext(options);
        }
    }
}
