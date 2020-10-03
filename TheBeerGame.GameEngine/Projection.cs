using System.Collections.Generic;
using System.Reflection;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{
    public class Projection
    {
        public long LastEventSeen { get; private set; }= -1;

        public void Apply(IEnumerable<StreamEvent> events)
        {
            foreach (var @event in events)
            {
                ApplyEvent(@event);
            }
        }

        public void Apply(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                ApplyEvent(@event);
            }
        }

        private void ApplyEvent(StreamEvent @event)
        {
            var e = @event.GetOriginatingEvent;
            ApplyEvent(e);
            LastEventSeen = @event.StreamPosition;
        }

        protected void ApplyEvent(Event @event)
        {
            var type = this.GetType();
            type.InvokeMember("Apply", BindingFlags.InvokeMethod, null, this, new object?[] {@event});
        }

        public void Apply(Event _)
        {
   
        }

    }
}