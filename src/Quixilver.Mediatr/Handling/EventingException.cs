using System;

namespace Quixilver.Eventing
{
    public class EventingException : Exception
    {
        public EventingException(AppEvent appEvent) : base($"Error publishing event {appEvent.ToString()}")
        {
            AppEvent = appEvent;
        }

        public EventingException(AppEvent appEvent, string message) : base(message)
        {
            AppEvent = appEvent;
        }

        public EventingException(AppEvent appEvent, Exception exception) : base($"Error publishing event {appEvent.ToString()}", exception)
        {
            AppEvent = appEvent;
        }

        public EventingException(AppEvent appEvent, string message, Exception exception) : base(message, exception)
        {
            AppEvent = appEvent;
        }

        public AppEvent AppEvent { get; private set; }
    }
}
