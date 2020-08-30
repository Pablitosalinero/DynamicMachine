using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using DynamicMachine.Contracts;
using DynamicMachine.plugin;
using System;

namespace DynamicMachineTests
{
    public abstract class UnitTestBase
    {
        protected IServiceProvider _serviceProvider;

        public UnitTestBase()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddMediatR(typeof(DynamicMachineLimited));
            serviceCollection.AddAutoMapper(typeof(DynamicMachineLimited));
            serviceCollection.AddScoped<IDynamicMachine, DynamicMachineLimited>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}

