#nullable enable
using System.Collections.Generic;
using System.Linq;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{


    public abstract class AggregateRoot : Projection
    {
        public string StreamName { get; }
        protected readonly List<Event> Uncommitted = new List<Event>();

   

        protected AggregateRoot(string streamName, string id)
        {
            StreamName = BuildStreamName(streamName, id);
        }

        public string BuildStreamName(string streamName, string id) => $"{StreamName}-{id}";

        public EventsToWrite GetEventsToWrite()
        {
            return new EventsToWrite(LastEventSeen + 1, StreamName, Uncommitted.ToList());
        }

        public void ApplyUncommitted()
        {
            Apply(Uncommitted);
            Uncommitted.Clear();
        }
    }
}