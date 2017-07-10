// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.EntityFrameworkCore
{
    public static class QueryTestHelpers
    {
        public static Func<dynamic, dynamic> GroupingSorter<TKey, TElement>()
            => e => ((IGrouping<TKey, TElement>)e).Key + " " + CollectionSorter<TElement>()(e);

        public static Func<dynamic, dynamic> CollectionSorter<TElement>()
            => e => ((IEnumerable<TElement>)e).Count();

        public static Action<dynamic, dynamic> GroupingAsserter<TKey, TElement>(Func<TElement, object> elementSorter = null)
        {
            return (e, a) =>
                {
                    Assert.Equal(((IGrouping<TKey, TElement>)e).Key, ((IGrouping<TKey, TElement>)a).Key);
                    CollectionAsserter(elementSorter)(e, a);
                };
        }

        public static Action<dynamic, dynamic> CollectionAsserter<TElement>(Func<TElement, object> elementSorter = null)
        {
            return (e, a) =>
                {
                    var actual = elementSorter != null
                        ? ((IEnumerable<TElement>)a).OrderBy(elementSorter).ToList()
                        : ((IEnumerable<TElement>)a).ToList();

                    var expected = elementSorter != null
                        ? ((IEnumerable<TElement>)e).OrderBy(elementSorter).ToList()
                        : ((IEnumerable<TElement>)e).ToList();

                    Assert.Equal(expected.Count, actual.Count);
                    for (var i = 0; i < expected.Count; i++)
                    {
                        Assert.Equal(expected[i], actual[i]);
                    }
                };
        }
    }
}
