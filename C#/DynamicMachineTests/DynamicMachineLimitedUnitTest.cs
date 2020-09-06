
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using DynamicMachine.Contracts;
using System.Threading.Tasks;
using Xunit;
using System.Collections;

namespace DynamicMachineTests
{
    public class DynamicMachineLimitedUnitTest : UnitTestBase
    {
        [Fact]
        public Task Test1()
        {
            //Act
            var dynamicMachineLimited = _serviceProvider.GetService<IDynamicMachine>();
            int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 200, 500 };
            int[] limits = new int[] { 4050, 2, 1, 1, 1, 4 , 1, 2, 4};
            int value = 222;
            var res = dynamicMachineLimited.Change(new ArrayList(coins),value, new ArrayList(limits),coins.Length);

            //Assert
            res.Should().NotBeNull();
            res.Should().HaveCount(9);
            return Task.CompletedTask;
        }
        [Fact]
        public Task Test2()
        {
            //Act
            var dynamicMachineLimited = _serviceProvider.GetService<IDynamicMachine>();
            int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100 };
            int[] limits = new int[] { 4050, 2, 1, 60, 4, 2, 6 };
            int value = 69;
            var res = dynamicMachineLimited.ChangeParallel(new ArrayList(coins), value, new ArrayList(limits), coins.Length);

            //Assert
            res.Should().NotBeNull();
            res.Should().HaveCount(7);
            return Task.CompletedTask;
        }
    }
}