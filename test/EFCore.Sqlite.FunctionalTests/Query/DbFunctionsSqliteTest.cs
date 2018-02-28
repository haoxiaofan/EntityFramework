// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query
{
    public class DbFunctionsSqliteTest : DbFunctionsTestBase<NorthwindQuerySqliteFixture<NoopModelCustomizer>>
    {
        public DbFunctionsSqliteTest(NorthwindQuerySqliteFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            fixture.TestSqlLoggerFactory.Clear();
        }

        public override void DateDiff_Year()
        {
            base.DateDiff_Year();

            AssertSql(
                @"SELECT COUNT(*)
FROM ""Orders"" AS ""c""
WHERE (CAST(strftime('%Y', rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.')) AS INTEGER) - CAST(strftime('%Y', ""c"".""OrderDate"") AS INTEGER)) = 0");
        }

        public override void DateDiff_Month()
        {
            base.DateDiff_Month();

            AssertSql(
                @"SELECT COUNT(*)
FROM ""Orders"" AS ""c""
WHERE ((12 * (CAST(strftime('%Y', rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.')) AS INTEGER) - CAST(strftime('%Y', ""c"".""OrderDate"") AS INTEGER))) + (CAST(strftime('%m', rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.')) AS INTEGER) - CAST(strftime('%m', ""c"".""OrderDate"") AS INTEGER))) = 0");

        }

        public override void DateDiff_Day()
        {
            base.DateDiff_Day();

            AssertSql(
                @"SELECT COUNT(*)
FROM ""Orders"" AS ""c""
WHERE (julianday(rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.'), 'start of day') - julianday(""c"".""OrderDate"", 'start of day')) = 0");

        }

        public override void DateDiff_Hour()
        {
            base.DateDiff_Hour();

            AssertSql(
                @"SELECT COUNT(*)
FROM ""Orders"" AS ""c""
WHERE ((24 * (julianday(rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.'), 'start of day') - julianday(""c"".""OrderDate"", 'start of day'))) + (CAST(strftime('%H', rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.')) AS INTEGER) - CAST(strftime('%H', ""c"".""OrderDate"") AS INTEGER))) = 0");

        }

        public override void DateDiff_Minute()
        {
            base.DateDiff_Minute();

            AssertSql(
                @"SELECT COUNT(*)
FROM ""Orders"" AS ""c""
WHERE ((60 * ((24 * (julianday(rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.'), 'start of day') - julianday(""c"".""OrderDate"", 'start of day'))) + (CAST(strftime('%H', rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.')) AS INTEGER) - CAST(strftime('%H', ""c"".""OrderDate"") AS INTEGER)))) + (CAST(strftime('%M', rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.')) AS INTEGER) - CAST(strftime('%M', ""c"".""OrderDate"") AS INTEGER))) = 0");
        }

        public override void DateDiff_Second()
        {
            base.DateDiff_Second();

            AssertSql(
                @"SELECT COUNT(*)
FROM ""Orders"" AS ""c""
WHERE ((60 * ((60 * ((24 * (julianday(rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.'), 'start of day') - julianday(""c"".""OrderDate"", 'start of day'))) + (CAST(strftime('%H', rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.')) AS INTEGER) - CAST(strftime('%H', ""c"".""OrderDate"") AS INTEGER)))) + (CAST(strftime('%M', rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.')) AS INTEGER) - CAST(strftime('%M', ""c"".""OrderDate"") AS INTEGER)))) + (CAST(strftime('%S', rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0'), '.')) AS INTEGER) - CAST(strftime('%S', ""c"".""OrderDate"") AS INTEGER))) = 0");

        }

        private void AssertSql(params string[] expected)
            => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
    }
}
