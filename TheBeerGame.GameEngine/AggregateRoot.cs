#nullable enable
using System.Collections.Generic;
using System.Linq;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{
    public class AggregateRoot : Projection
    {
        protected readonly List<Event> Uncommitted = new List<Event>();

        public List<Event> GetUncommittedEvents()
        {
            return Uncommitted.ToList();
        }

        public void ApplyUncommitted()
        {
            Apply(Uncommitted);
            Uncommitted.Clear();
        }
    }
}