using System;
using Xunit.Abstractions;
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.EntityFrameworkCore.Query
{
    public class ResultOperatorsQuerySqliteTest : QueryTestBase<NorthwindQuerySqliteFixture>
    {
        // ReSharper disable once UnusedParameter.Local
        public ResultOperatorsQuerySqliteTest(NorthwindQuerySqliteFixture fixture, ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            fixture.TestSqlLoggerFactory.Clear();
        }

        public override void Sum_with_coalesce()
        {
            base.Sum_with_coalesce();

            Assert.Contains(
                @"SELECT SUM(COALESCE(""p"".""UnitPrice"", 0.0))
FROM ""Products"" AS ""p""
WHERE ""p"".""ProductID"" < 40",
                Sql);
        }
    }
}
