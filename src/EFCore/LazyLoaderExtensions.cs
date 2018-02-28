// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    ///     Extension methods for the <see cref="ILazyLoader" /> service that make it more
    ///     convenient to use from entity classes.
    /// </summary>
    public static class LazyLoaderExtensions
    {
        /// <summary>
        ///     Loads a navigation property if it has not already been loaded.
        /// </summary>
        /// <typeparam name="TRelated"> The type of the navigation property. </typeparam>
        /// <param name="loader">The loader instance, which may be <c>null</c>.</param>
        /// <param name="entity"> The entity on which the navigation property is located. </param>
        /// <param name="navigationField"> A reference to the backing field for the navigation. </param>
        /// <param name="navigationName"> The navigation property name. </param>
        /// <returns>
        ///     The loaded navigation property value, or the navigation property value unchanged if the loader is <c>null</c>.
        /// </returns>
        public static TRelated Load<TRelated>(
            [CanBeNull] this ILazyLoader loader,
            [NotNull] object entity,
            [CanBeNull] ref TRelated navigationField,
            // ReSharper disable once AssignNullToNotNullAttribute
            [NotNull] [CallerMemberName] string navigationName = null)
            where TRelated : class
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            loader?.Load(entity, navigationName);

            return navigationField;
        }
    }
}
