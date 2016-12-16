using System;
using MediatR;

namespace Quixilver.Eventing.UnitTests
{
    public class TestNotification : INotification
    {
        public string Message { get; set; }
    }
}
