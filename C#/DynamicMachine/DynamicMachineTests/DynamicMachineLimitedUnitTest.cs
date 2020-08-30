
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using DynamicMachine.Contracts;
using System.Threading.Tasks;
using Xunit;

namespace DynamicMachineTests
{
    public class DynamicMachineLimitedUnitTest : UnitTestBase
    {
        [Fact]
        public Task Test1()
        {
            //Act
            var dynamicMachineLimited = _serviceProvider.GetService<IDynamicMachine>();
            var res = dynamicMachineLimited.Change();

            //Assert
            res.Should().NotBeNull();
            res.Should().HaveCount(0);
            return Task.CompletedTask;
        }
    }
}