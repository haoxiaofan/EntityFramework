// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public abstract class ISetExtractor<TContext> where TContext : DbContext
    {
        public abstract IQueryable<TEntity> Set<TEntity>(TContext context) where TEntity : class;
    }
}
