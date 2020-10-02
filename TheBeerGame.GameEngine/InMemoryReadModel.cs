using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{
    public abstract class SubscribedProjection : Projection
    {
        private readonly IEventStore _eventStore;
        private readonly string _streamName;

        protected SubscribedProjection(IEventStore eventStore, string streamName)
        {
            _eventStore = eventStore;
            _streamName = streamName;
        }

        public void Start()
        {
            _eventStore.SubscribeToStream(_streamName, @event =>
            {
                var e = @event.GetOriginatingEvent;
                ApplyEvent(@event.GetOriginatingEvent);
            });
        }
    }

    public class InMemoryReadModel : Projection
    {
    }
}