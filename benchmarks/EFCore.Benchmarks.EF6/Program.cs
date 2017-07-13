﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore.Benchmarks.EF6.ChangeTracker;
using Microsoft.EntityFrameworkCore.Benchmarks.EF6.Query;
using Microsoft.EntityFrameworkCore.Benchmarks.EF6.UpdatePipeline;

namespace Microsoft.EntityFrameworkCore.Benchmarks.EF6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var benchmarkSummaryProcessor = new BenchmarkSummaryProcessor();

            // Initialization
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<InitializationTests>());

            // ChangeTracker
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<DbSetOperationTests.AddDataVariations>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<DbSetOperationTests.ExistingDataVariations>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<FixupTests.ChildVariation>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<FixupTests.ParentVariation>());

            // Query
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<DbSetOperationTests.AddDataVariations>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<DbSetOperationTests.ExistingDataVariations>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<FuncletizationTests>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<NavigationsQueryTests>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<QueryCompilationTests>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<RawSqlQueryTests>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<SimpleQueryTests>());

            // Update
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<SimpleUpdatePipelineTests.Insert>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<SimpleUpdatePipelineTests.Update>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<SimpleUpdatePipelineTests.Delete>());
            benchmarkSummaryProcessor.Process(BenchmarkRunner.Run<SimpleUpdatePipelineTests.Mixed>());
        }
    }
}
