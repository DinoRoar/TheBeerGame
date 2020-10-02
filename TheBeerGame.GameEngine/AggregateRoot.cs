#nullable enable
using System.Collections.Generic;
using System.Linq;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{
    public abstract class AggregateRoot : Projection
    {
        private readonly string _streamName;
        protected readonly List<Event> Uncommitted = new List<Event>();

   

        protected AggregateRoot(string streamName)
        {
            _streamName = streamName;
        }

        public string BuildStreamName(string id) => $"{_streamName}-{id}";

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