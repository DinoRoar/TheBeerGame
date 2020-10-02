using System.Collections.Generic;
using System.Reflection;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{
    public class Projection
    {
        public virtual void Apply(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                var type = this.GetType();
                type.InvokeMember("Apply", BindingFlags.InvokeMethod, null, this, new object?[] { @event });
            }
        }

        public void Apply(Event _)
        {
   
        }

    }
}