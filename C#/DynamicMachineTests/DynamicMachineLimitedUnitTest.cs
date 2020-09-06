
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
        public Task TestLineal()
        {
            //Act
            var dynamicMachineLimited = _serviceProvider.GetService<IDynamicMachine>();
            //int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };
            int[] coins = new int[] { 1, 5, 10, 20, 50, 100, 200, 500 };
            //int[] limits = new int[] { 4050, 2, 1, 1, 1, 200, 1, 2, 5 };
            int[] limits = new int[] { 4050, 2, 1, 1, 1, 200, 1, 2, 5 };
            int value = 256;
            var res = dynamicMachineLimited.Change(new ArrayList(coins),value, new ArrayList(limits),coins.Length);

            //Assert
            res.Should().NotBeNull();
            res.Should().HaveCount(coins.Length);
            int result = 0;
            int index = 0;
            foreach (int elem in res)
            {
                elem.Should().BeLessOrEqualTo(limits[index]);
                result += elem * coins[index];
                index++;
            }
            result.Should().Be(value);
            return Task.CompletedTask;
        }
        [Fact]
        public Task TestParallel()
        {
            //Act
            var dynamicMachineLimited = _serviceProvider.GetService<IDynamicMachine>();
            int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 200, 500 };
            int[] limits = new int[] { 4050, 2, 1, 1, 200, 4, 1, 2, 5 };
            int value = 50;
            var res = dynamicMachineLimited.ChangeParallel(new ArrayList(coins), value, new ArrayList(limits), coins.Length);

            //Assert
            res.Should().NotBeNull();
            res.Should().HaveCount(coins.Length);
            int result = 0;
            int index = 0;
            foreach(int elem in res)
            {
                elem.Should().BeLessThan(limits[index]);
                result += elem * coins[index];
                index++;
            }
            result.Should().Be(value);
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(20)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(29)]
        [InlineData(30)]
        [InlineData(31)]
        [InlineData(32)]
        [InlineData(33)]
        [InlineData(34)]
        [InlineData(35)]
        [InlineData(36)]
        [InlineData(37)]
        [InlineData(38)]
        [InlineData(39)]
        [InlineData(40)]
        [InlineData(41)]
        [InlineData(42)]
        [InlineData(43)]
        [InlineData(44)]
        [InlineData(45)]
        [InlineData(46)]
        [InlineData(47)]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(50)]
        public Task TheoryLineal(int value)
        {
            //Act
            var dynamicMachineLimited = _serviceProvider.GetService<IDynamicMachine>();
            int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 200, 500 };
            int[] limits = new int[] { 4050, 2, 1, 1, 1, 200, 1, 2, 5 };
            var res = dynamicMachineLimited.Change(new ArrayList(coins), value, new ArrayList(limits), coins.Length);

            //Assert
            res.Should().NotBeNull();
            res.Should().HaveCount(coins.Length);
            int result = 0;
            int index = 0;
            foreach (int elem in res)
            {
                elem.Should().BeLessOrEqualTo(limits[index]);
                result += elem * coins[index];
                index++;
            }
            result.Should().Be(value);
            return Task.CompletedTask;
        }
    }
}