using System;
using MediatR;

namespace Quixilver.Eventing.UnitTests
{
    public class TestAsyncNotification : IAsyncNotification
    {
        public string Message { get; set; }
    }
}
