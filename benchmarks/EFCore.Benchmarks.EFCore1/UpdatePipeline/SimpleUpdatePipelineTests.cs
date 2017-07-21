// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore.Benchmarks.EFCore1.Models.Orders;
using Microsoft.EntityFrameworkCore.Benchmarks.Models.Orders;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Benchmarks.EFCore1.UpdatePipeline
{
    public class SimpleUpdatePipelineTests
    {
        public abstract class Base
        {
            protected static readonly SimpleUpdatePipelineFixture Fixture = new SimpleUpdatePipelineFixture();
            protected OrdersContext Context;
            protected IDbContextTransaction Transaction;
            protected List<Customer> Customers;
            private int _recordsAffected = -1;

            [Params(true, false)]
            public bool Async;

            [Params(true, false)]
            public bool Batching;

            [IterationSetup]
            public abstract void InitializeContext();

            [IterationCleanup]
            public void CleanupContext()
            {
                if (_recordsAffected != -1)
                {
                    Assert.Equal(1000, _recordsAffected);
                }

                Transaction.Dispose();
                Context.Dispose();
            }

            [Benchmark]
            public async Task UpdatePipeline()
            {
                _recordsAffected = Async
                    ? await Context.SaveChangesAsync()
                    : Context.SaveChanges();
            }
        }

        public class Insert : Base
        {
            [IterationSetup]
            public override void InitializeContext()
            {
                Context = Fixture.CreateContext(Batching);
                Transaction = Context.Database.BeginTransaction();
                Customers = Fixture.CreateCustomers(1000, setPrimaryKeys: false);
                Context.Customers.AddRange(Customers);
            }
        }

        public class Update : Base
        {
            [IterationSetup]
            public override void InitializeContext()
            {
                Context = Fixture.CreateContext(Batching);
                Transaction = Context.Database.BeginTransaction();

                foreach (var customer in Context.Customers)
                {
                    customer.FirstName += " Modified";
                }
            }
        }

        public class Delete : Base
        {
            [IterationSetup]
            public override void InitializeContext()
            {
                Context = Fixture.CreateContext(Batching);
                Transaction = Context.Database.BeginTransaction();

                Context.Customers.RemoveRange(Context.Customers.ToList());
            }
        }

        public class Mixed : Base
        {
            [IterationSetup]
            public override void InitializeContext()
            {
                Context = Fixture.CreateContext(Batching);
                Transaction = Context.Database.BeginTransaction();
                var existingCustomers = Context.Customers.ToArray();

                var newCustomers = Fixture.CreateCustomers(333, setPrimaryKeys: false);
                Context.Customers.AddRange(newCustomers);

                for (var i = 0; i < 1000; i += 3)
                {
                    Context.Customers.Remove(existingCustomers[i]);
                }

                for (var i = 1; i < 1000; i += 3)
                {
                    existingCustomers[i].FirstName += " Modified";
                }
            }
        }

        public class SimpleUpdatePipelineFixture : OrdersFixture
        {
            public SimpleUpdatePipelineFixture()
                : base("Perf_UpdatePipeline_Simple", 0, 1000, 0, 0)
            {
            }

            public OrdersContext CreateContext(bool disableBatching) => new OrdersContext(ConnectionString, disableBatching);
        }
    }
}
