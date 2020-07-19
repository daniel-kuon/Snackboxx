using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly:TestCaseOrderer("Core.Tests.TestCaseOrderer", "Tests")]
namespace Core.Tests
{
    public class TestCaseOrderer : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
            where TTestCase : ITestCase
        {
            var result = testCases.ToList();
            var init = result.FirstOrDefault(t => t.TestMethod.Method.Name == nameof(EnsureDatabaseExists.UpdateDatabase));
            return init != null ? new[] {init}.Union(result.Except(new [] {init})).ToList() : result;
        }
    }
}