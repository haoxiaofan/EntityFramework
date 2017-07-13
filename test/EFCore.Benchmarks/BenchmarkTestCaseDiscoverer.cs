// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Microsoft.EntityFrameworkCore.Benchmarks
{
    public class BenchmarkTestCaseDiscoverer : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink _diagnosticMessageSink;

        public BenchmarkTestCaseDiscoverer(IMessageSink diagnosticMessageSink)
        {
            _diagnosticMessageSink = diagnosticMessageSink;
        }

        public virtual IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            var variations = testMethod.Method
                .GetCustomAttributes(typeof(BenchmarkVariationAttribute))
                .Select(a => new
                {
                    Name = a.GetNamedArgument<string>(nameof(BenchmarkVariationAttribute.VariationName)),
                    Iterations = a.GetNamedArgument<int?>(nameof(BenchmarkVariationAttribute.Iterations)),
                    TestMethodArguments = a.GetNamedArgument<object[]>(nameof(BenchmarkVariationAttribute.Data))
                })
                .ToList();

            if (!variations.Any())
            {
                variations.Add(new
                {
                    Name = "Default",
                    Iterations = (int?)null,
                    TestMethodArguments = new object[0]
                });
            }

            var tests = new List<IXunitTestCase>();
            foreach (var variation in variations)
            {
                if (BenchmarkConfig.Instance.RunIterations)
                {
                    tests.Add(new BenchmarkTestCase(
                        variation.Iterations ?? factAttribute.GetNamedArgument<int>(nameof(BenchmarkOldAttribute.Iterations)),
                        factAttribute.GetNamedArgument<int>(nameof(BenchmarkOldAttribute.WarmupIterations)),
                        variation.Name,
                        _diagnosticMessageSink,
                        testMethod,
                        variation.TestMethodArguments));
                }
                else
                {
                    tests.Add(new NonCollectingBenchmarkTestCase(
                        variation.Name,
                        _diagnosticMessageSink,
                        testMethod,
                        variation.TestMethodArguments));
                }
            }

            return tests;
        }
    }
}
