// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore.Benchmarks.EFCore1.Models.Orders;
using Microsoft.EntityFrameworkCore.Benchmarks.Models.Orders;

namespace Microsoft.EntityFrameworkCore.Benchmarks.EFCore1.ChangeTracker
{
    public class DbSetOperationTests
    {
        public abstract class Base
        {
            protected readonly DbSetOperationFixture Fixture = new DbSetOperationFixture();
            protected List<Customer> CustomersWithoutPk;
            protected List<Customer> CustomersWithPk;
            protected OrdersContext Context;

            [Params(true, false)]
            public bool AutoDetectChanges { get; set; }

            [GlobalSetup]
            public void CreateCustomers()
            {
                CustomersWithoutPk = Fixture.CreateCustomers(20000, setPrimaryKeys: false);
                CustomersWithPk = Fixture.CreateCustomers(20000, setPrimaryKeys: true);
            }

            [IterationCleanup]
            public void CleanupContext()
            {
                Context.Dispose();
            }
        }

        public class AddDataVariations : Base
        {
            [IterationSetup]
            public void InitializeContext()
            {
                Context = Fixture.CreateContext();
                Context.ChangeTracker.AutoDetectChangesEnabled = AutoDetectChanges;
            }

            [Benchmark]
            public void Add()
            {
                foreach (var customer in CustomersWithoutPk)
                {
                    Context.Customers.Add(customer);
                }
            }

            [Benchmark]
            public void AddRange()
            {
                Context.Customers.AddRange(CustomersWithoutPk);
            }

            [Benchmark]
            public void Attach()
            {
                foreach (var customer in CustomersWithPk)
                {
                    Context.Customers.Attach(customer);
                }
            }

            [Benchmark]
            public void AttachRange()
            {
                Context.Customers.AttachRange(CustomersWithPk);
            }
        }

        public class ExistingDataVariations : Base
        {
            [IterationSetup]
            public void InitializeContext()
            {
                Context = Fixture.CreateContext();
                Context.ChangeTracker.AutoDetectChangesEnabled = AutoDetectChanges;
                Context.Customers.AttachRange(CustomersWithPk);
            }

            [Benchmark]
            public void Remove()
            {
                foreach (var customer in CustomersWithPk)
                {
                    Context.Customers.Remove(customer);
                }
            }

            [Benchmark]
            public void RemoveRange()
            {
                Context.Customers.RemoveRange(CustomersWithPk);
            }

            [Benchmark]
            public void Update()
            {
                foreach (var customer in CustomersWithPk)
                {
                    Context.Customers.Update(customer);
                }
            }

            [Benchmark]
            public void UpdateRange()
            {
                Context.Customers.UpdateRange(CustomersWithPk);
            }
        }

        public class DbSetOperationFixture : OrdersFixture
        {
            public DbSetOperationFixture()
                : base("Perf_ChangeTracker_DbSetOperation", 0, 0, 0, 0)
            {
            }
        }
    }
}
