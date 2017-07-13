// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query
{
    public interface IQueryAsserter
    {
        #region AssertSingleResult

        //void AssertSingleResult<TItem1>(
        //    Func<IQueryable<TItem1>, object> query,
        //    Action<object, object> asserter = null,
        //    int entryCount = 0)
        //    where TItem1 : class;

        void AssertSingleResult<TItem1>(
            Func<IQueryable<TItem1>, object> actualQuery,
            Func<IQueryable<TItem1>, object> expectedQuery,
            Action<object, object> asserter = null,
            int entryCount = 0)
            where TItem1 : class;

        //void AssertSingleResult<TItem1, TItem2>(
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, object> query,
        //    Action<object, object> asserter = null,
        //    int entryCount = 0)
        //    where TItem1 : class
        //    where TItem2 : class;

        void AssertSingleResult<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, object> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, object> expectedQuery,
            Action<object, object> asserter = null,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class;

        //void AssertSingleResult<TItem1, TItem2, TItem3>(
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, object> query,
        //    Action<object, object> asserter = null,
        //    int entryCount = 0)
        //    where TItem1 : class
        //    where TItem2 : class
        //    where TItem3 : class;

        void AssertSingleResult<TItem1, TItem2, TItem3>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, object> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, object> expectedQuery,
            Action<object, object> asserter = null,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class;

        #endregion

        #region AssertQuery

        //void AssertQuery<TItem1>(
        //    Func<IQueryable<TItem1>, IQueryable<object>> query,
        //    Func<dynamic, object> elementSorter = null,
        //    Action<dynamic, dynamic> elementAsserter = null,
        //    bool assertOrder = false,
        //    int entryCount = 0)
        //    where TItem1 : class;

        void AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0)
            where TItem1 : class;

        //void AssertQuery<TItem1, TItem2>(
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> query,
        //    Func<dynamic, object> elementSorter = null,
        //    Action<dynamic, dynamic> elementAsserter = null,
        //    bool assertOrder = false,
        //    int entryCount = 0)
        //    where TItem1 : class
        //    where TItem2 : class;

        void AssertQuery<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class;

        //void AssertQuery<TItem1, TItem2, TItem3>(
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<object>> query,
        //    Func<dynamic, object> elementSorter = null,
        //    Action<dynamic, dynamic> elementAsserter = null,
        //    bool assertOrder = false,
        //    int entryCount = 0)
        //    where TItem1 : class
        //    where TItem2 : class
        //    where TItem3 : class;

        void AssertQuery<TItem1, TItem2, TItem3>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class;

        #endregion

        #region AssertQueryScalar

        //void AssertQueryScalar<TItem1>(
        //    Func<IQueryable<TItem1>, IQueryable<int>> query,
        //    bool assertOrder = false)
        //    where TItem1 : class;

        //void AssertQueryScalar<TItem1>(
        //    Func<IQueryable<TItem1>, IQueryable<int>> actualQuery,
        //    Func<IQueryable<TItem1>, IQueryable<int>> expectedQuery,
        //    bool assertOrder = false)
        //    where TItem1 : class;

        //void AssertQueryScalar<TItem1>(
        //    Func<IQueryable<TItem1>, IQueryable<long>> query,
        //    bool assertOrder = false)
        //    where TItem1 : class;

        //void AssertQueryScalar<TItem1>(
        //    Func<IQueryable<TItem1>, IQueryable<short>> query,
        //    bool assertOrder = false)
        //    where TItem1 : class;

        //void AssertQueryScalar<TItem1>(
        //    Func<IQueryable<TItem1>, IQueryable<bool>> query,
        //    bool assertOrder = false)
        //    where TItem1 : class;

        //void AssertQueryScalar<TItem1, TResult>(
        //    Func<IQueryable<TItem1>, IQueryable<TResult>> query,
        //    bool assertOrder = false)
        //    where TItem1 : class
        //    where TResult : struct;

        void AssertQueryScalar<TItem1, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TResult>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TResult>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TResult : struct;

        //void AssertQueryScalar<TItem1, TItem2>(
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int>> query,
        //    bool assertOrder = false)
        //    where TItem1 : class
        //    where TItem2 : class;

        //void AssertQueryScalar<TItem1, TItem2>(
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int>> actualQuery,
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int>> expectedQuery,
        //    bool assertOrder = false)
        //    where TItem1 : class
        //    where TItem2 : class;

        void AssertQueryScalar<TItem1, TItem2, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TResult>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TResult>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            where TResult : struct;

        //void AssertQueryScalar<TItem1, TItem2, TItem3>(
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<int>> query,
        //    bool assertOrder = false)
        //    where TItem1 : class
        //    where TItem2 : class
        //    where TItem3 : class;

        void AssertQueryScalar<TItem1, TItem2, TItem3, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<TResult>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<TResult>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class
            where TResult : struct;

        #endregion

        #region AssertQueryScalar - nullable

        //void AssertQueryScalar<TItem1>(
        //    Func<IQueryable<TItem1>, IQueryable<int?>> query,
        //    bool assertOrder = false)
        //    where TItem1 : class;

        //void AssertQueryScalar<TItem1>(
        //    Func<IQueryable<TItem1>, IQueryable<int?>> actualQuery,
        //    Func<IQueryable<TItem1>, IQueryable<int?>> expectedQuery,
        //    bool assertOrder = false)
        //    where TItem1 : class;

        void AssertQueryScalar<TItem1, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TResult?>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TResult?>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TResult : struct;

        //void AssertQueryScalar<TItem1, TItem2>(
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int?>> query,
        //    bool assertOrder = false)
        //    where TItem1 : class
        //    where TItem2 : class;

        //void AssertQueryScalar<TItem1, TItem2>(
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int?>> actualQuery,
        //    Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int?>> expectedQuery,
        //    bool assertOrder = false)
        //    where TItem1 : class
        //    where TItem2 : class;

        void AssertQueryScalar<TItem1, TItem2, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TResult?>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TResult?>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            where TResult : struct;

        #endregion

        #region AssertIncludeQuery

        void AssertIncludeQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> query,
            List<IExpectedInclude> expectedIncludes,
            Func<dynamic, object> elementSorter = null,
            Func<dynamic, object> clientProjection = null)
            where TItem1 : class;

        void AssertIncludeQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> efQuery,
            Func<IQueryable<TItem1>, IQueryable<object>> l2oQuery,
            List<IExpectedInclude> expectedIncludes,
            Func<dynamic, object> elementSorter = null,
            Func<dynamic, object> clientProjection = null)
            where TItem1 : class;

        void AssertIncludeQuery<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> query,
            List<IExpectedInclude> expectedIncludes,
            Func<dynamic, object> elementSorter = null,
            Func<dynamic, object> clientProjection = null)
            where TItem1 : class
            where TItem2 : class;

        void AssertIncludeQuery<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> efQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> l2oQuery,
            List<IExpectedInclude> expectedIncludes,
            Func<dynamic, object> elementSorter = null,
            Func<dynamic, object> clientProjection = null)
            where TItem1 : class
            where TItem2 : class;

        #endregion
    }

    public class QueryFixtureBase
    {
        public IQueryAsserter QueryAsserter { get; set; }
    }

    public class QueryTestBase2<TFixture> : IClassFixture<TFixture>
        where TFixture : QueryFixtureBase, new()
    {
        #region AssertSingleResult

        protected virtual void AssertSingleResult<TItem1>(
            Func<IQueryable<TItem1>, object> query,
            Action<object, object> asserter = null,
            int entryCount = 0)
            where TItem1 : class
            =>  AssertSingleResult(query, query, asserter, entryCount);

        protected virtual void AssertSingleResult<TItem1>(
            Func<IQueryable<TItem1>, object> actualQuery,
            Func<IQueryable<TItem1>, object> expectedQuery,
            Action<object, object> asserter = null,
            int entryCount = 0)
            where TItem1 : class
            => Fixture.QueryAsserter.AssertSingleResult(actualQuery, expectedQuery, asserter, entryCount);

        public virtual void AssertSingleResult<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, object> query,
            Action<object, object> asserter = null,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            => AssertSingleResult(query, query, asserter, entryCount);

        public virtual void AssertSingleResult<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, object> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, object> expectedQuery,
            Action<object, object> asserter = null,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            => Fixture.QueryAsserter.AssertSingleResult(actualQuery, expectedQuery, asserter, entryCount);

        public virtual void AssertSingleResult<TItem1, TItem2, TItem3>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, object> query,
            Action<object, object> asserter = null,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class
            => AssertSingleResult(query, query, asserter, entryCount);

        public virtual void AssertSingleResult<TItem1, TItem2, TItem3>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, object> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, object> expectedQuery,
            Action<object, object> asserter = null,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class
            => Fixture.QueryAsserter.AssertSingleResult(actualQuery, expectedQuery, asserter, entryCount);

        #endregion

        #region AssertQuery

        public virtual void AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> query,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0)
            where TItem1 : class
            => AssertQuery(query, query, elementSorter, elementAsserter, assertOrder, entryCount);

        public virtual void AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0)
            where TItem1 : class
            => Fixture.QueryAsserter.AssertQuery(actualQuery, expectedQuery, elementSorter, elementAsserter, assertOrder, entryCount);

        public virtual void AssertQuery<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> query,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            => AssertQuery(query, query, elementSorter, elementAsserter, assertOrder, entryCount);

        public virtual void AssertQuery<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            => Fixture.QueryAsserter.AssertQuery(actualQuery, expectedQuery, elementSorter, elementAsserter, assertOrder, entryCount);

        public virtual void AssertQuery<TItem1, TItem2, TItem3>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<object>> query,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class
            => AssertQuery(query, query, elementSorter, elementAsserter, assertOrder, entryCount);

        public virtual void AssertQuery<TItem1, TItem2, TItem3>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class
            => Fixture.QueryAsserter.AssertQuery(actualQuery, expectedQuery, elementSorter, elementAsserter, assertOrder, entryCount);

        #endregion

        #region AssertQueryScalar

        public virtual void AssertQueryScalar<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<int>> query,
            bool assertOrder = false)
            where TItem1 : class
            => AssertQueryScalar(query, query, assertOrder);

        public virtual void AssertQueryScalar<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<int>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<int>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            => AssertQueryScalar<TItem1, int>(actualQuery, expectedQuery, assertOrder);

        public virtual void AssertQueryScalar<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<long>> query,
            bool assertOrder = false)
            where TItem1 : class
            => AssertQueryScalar(query, query, assertOrder);

        public virtual void AssertQueryScalar<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<short>> query,
            bool assertOrder = false)
            where TItem1 : class
            => AssertQueryScalar(query, query, assertOrder);

        public virtual void AssertQueryScalar<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<bool>> query,
            bool assertOrder = false)
            where TItem1 : class
            => AssertQueryScalar(query, query, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TResult>> query,
            bool assertOrder = false)
            where TItem1 : class
            where TResult : struct
            => AssertQueryScalar(query, query, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TResult>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TResult>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TResult : struct
            => Fixture.QueryAsserter.AssertQueryScalar(actualQuery, expectedQuery, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int>> query,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            => AssertQueryScalar(query, query, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            => AssertQueryScalar<TItem1, TItem2, int>(actualQuery, expectedQuery, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TItem2, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TResult>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TResult>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            where TResult : struct
            => Fixture.QueryAsserter.AssertQueryScalar(actualQuery, expectedQuery, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TItem2, TItem3>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<int>> query,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class
            => AssertQueryScalar(query, query, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TItem2, TItem3, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<TResult>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<TResult>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class
            where TResult : struct
            => Fixture.QueryAsserter.AssertQueryScalar(actualQuery, expectedQuery, assertOrder);

        #endregion

        #region AssertQueryScalar - nullable

        public virtual void AssertQueryScalar<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<int?>> query,
            bool assertOrder = false)
            where TItem1 : class
            => AssertQueryScalar(query, query, assertOrder);

        public virtual void AssertQueryScalar<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<int?>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<int?>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            => AssertQueryScalar<TItem1, int>(actualQuery, expectedQuery, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TResult?>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TResult?>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TResult : struct
            => Fixture.QueryAsserter.AssertQueryScalar(actualQuery, expectedQuery, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int?>> query,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            => AssertQueryScalar(query, query, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int?>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<int?>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            => AssertQueryScalar<TItem1, TItem2, int>(actualQuery, expectedQuery, assertOrder);

        public virtual void AssertQueryScalar<TItem1, TItem2, TResult>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TResult?>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TResult?>> expectedQuery,
            bool assertOrder = false)
            where TItem1 : class
            where TItem2 : class
            where TResult : struct
            => Fixture.QueryAsserter.AssertQueryScalar(actualQuery, expectedQuery, assertOrder);

        #endregion

        #region AssertIncludeQuery

        public void AssertIncludeQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> query,
            List<IExpectedInclude> expectedIncludes,
            Func<dynamic, object> elementSorter = null,
            Func<dynamic, object> clientProjection = null)
            where TItem1 : class
            => AssertIncludeQuery(query, query, expectedIncludes, elementSorter, clientProjection);

        public void AssertIncludeQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> efQuery,
            Func<IQueryable<TItem1>, IQueryable<object>> l2oQuery,
            List<IExpectedInclude> expectedIncludes,
            Func<dynamic, object> elementSorter = null,
            Func<dynamic, object> clientProjection = null)
            where TItem1 : class
        {
            using (var context = _contextCreator())
            {
                var actual = efQuery(_setExtractor.Set<TItem1>(context)).ToList();
                var expected = l2oQuery(_expectedData.Set<TItem1>()).ToList();

                if (elementSorter != null)
                {
                    actual = actual.OrderBy(elementSorter).ToList();
                    expected = expected.OrderBy(elementSorter).ToList();
                }

                if (clientProjection != null)
                {
                    actual = actual.Select(clientProjection).ToList();
                    expected = expected.Select(clientProjection).ToList();
                }

                _includeResultAsserter.AssertResult(expected, actual, expectedIncludes);
            }
        }

        public void AssertIncludeQuery<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> query,
            List<IExpectedInclude> expectedIncludes,
            Func<dynamic, object> elementSorter = null,
            Func<dynamic, object> clientProjection = null)
            where TItem1 : class
            where TItem2 : class
            => AssertIncludeQuery(query, query, expectedIncludes, elementSorter, clientProjection);

        public void AssertIncludeQuery<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> efQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> l2oQuery,
            List<IExpectedInclude> expectedIncludes,
            Func<dynamic, object> elementSorter = null,
            Func<dynamic, object> clientProjection = null)
            where TItem1 : class
            where TItem2 : class
        {
            using (var context = _contextCreator())
            {
                var actual = efQuery(
                    _setExtractor.Set<TItem1>(context),
                    _setExtractor.Set<TItem2>(context)).ToList();

                var expected = l2oQuery(
                    _expectedData.Set<TItem1>(),
                    _expectedData.Set<TItem2>()).ToList();

                if (elementSorter != null)
                {
                    actual = actual.OrderBy(elementSorter).ToList();
                    expected = expected.OrderBy(elementSorter).ToList();
                }

                if (clientProjection != null)
                {
                    actual = actual.Select(clientProjection).ToList();
                    expected = expected.Select(clientProjection).ToList();
                }

                _includeResultAsserter.AssertResult(expected, actual, expectedIncludes);
            }
        }

        #endregion

        protected TFixture Fixture { get; }
    }
}