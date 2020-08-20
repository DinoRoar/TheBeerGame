using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace TheBeerGame.GameEngine
{
    public class AggregateRoot
    {
        private readonly ILogger _logger;
        protected readonly List<Event> Uncommitted = new List<Event>();

        public AggregateRoot(ILogger logger)
        {
            _logger = logger;
        }
        public void Apply(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                Apply((dynamic)@event);
            }
        }

        public void Apply(Event fallback)
        {
            var aggregateRoot = this.GetType().FullName;
            var eventType = fallback.Type;
            _logger.Debug("{@aggregateRoot} does not handle event {eventType}", aggregateRoot, eventType);
        }

        public IEnumerable<Event> GetUncommittedEvents()
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