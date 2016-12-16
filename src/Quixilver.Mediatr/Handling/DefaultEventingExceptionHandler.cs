using System;
using System.Diagnostics;

namespace Quixilver.Eventing.Handling
{
    public class DefaultEventingExceptionHandler : IEventingExceptionHandler
    {
        public void Handle(Exception ex)
        {
            Debug.WriteLine($"Exception publishing event(s) : {ex.Message}");
        }
    }
}
