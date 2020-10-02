using Serilog;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{
    public class SubscribedProjection : Projection
    {
        private readonly IEventStore _eventStore;

        public SubscribedProjection(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

    }

    public class InMemoryReadModel : Projection
    {
        public InMemoryReadModel(ILogger logger) : base()
        {
        }
    }
}