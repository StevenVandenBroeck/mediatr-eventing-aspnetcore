using System;
using System.Diagnostics;

namespace Quixilver.Eventing.UnitTests
{
    public class TestExceptionHandler : IEventingExceptionHandler
    {
        public void Handle(EventingException ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
