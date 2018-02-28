// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.EntityFrameworkCore.Storage.Converters
{
    /// <summary>
    ///     Converts <see cref="TimeSpan" /> to and from strings.
    /// </summary>
    public class TimeSpanToStringConverter : ValueConverter<TimeSpan, string>
    {
        private static readonly ConverterMappingHints _defaultHints
            = new ConverterMappingHints(size: 48);

        /// <summary>
        ///     Creates a new instance of this converter.
        /// </summary>
        /// <param name="mappingHints">
        ///     Hints that can be used by the <see cref="ITypeMappingSource"/> to create data types with appropriate
        ///     facets for the converted data.
        /// </param>
        public TimeSpanToStringConverter(ConverterMappingHints mappingHints = default)
            : base(
                v => v.ToString("c"),
                v => v == null ? default : TimeSpan.Parse(v, CultureInfo.InvariantCulture),
                mappingHints.With(_defaultHints))
        {
        }

        /// <summary>
        ///     A <see cref="ValueConverterInfo" /> for the default use of this converter.
        /// </summary>
        public static ValueConverterInfo DefaultInfo { get; }
            = new ValueConverterInfo(typeof(TimeSpan), typeof(string), i => new TimeSpanToStringConverter(i.MappingHints), _defaultHints);
    }
}
