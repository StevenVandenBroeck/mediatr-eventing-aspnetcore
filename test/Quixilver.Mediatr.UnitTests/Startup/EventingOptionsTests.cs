using System;
using Microsoft.Extensions.DependencyInjection;
using Quixilver.Eventing.Handling;
using Xunit;

namespace Quixilver.Eventing.UnitTests.Startup
{
    public class EventingOptionsTests
    {
        [Fact]
        void ExceptionHandlerTypeIsInitialized()
        {
            var services = new ServiceCollection();
            var options = new EventingOptions(services);
            Assert.Equal(typeof(DefaultEventingExceptionHandler), options.ExceptionHandlerType);
        }

        [Fact]
        void ExceptionHandlerTypeIsRegistered()
        {
            var services = new ServiceCollection();
            var options = new EventingOptions(services);
            options.RegisterExceptionHandler<TestExceptionHandler>();
            Assert.Equal(typeof(TestExceptionHandler), options.ExceptionHandlerType);
        }

        // ToDo (SVB) : testen voor RegisterEventHandler & RegisterAsyncEventHandler
    }
}
