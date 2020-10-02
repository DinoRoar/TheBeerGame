using System;
using System.Collections.Generic;
using System.Text;
using EventStore.ClientAPI;
using TheBeerGame.EventStore;

namespace TheBeerGame.Dave
{
    class EventStoreClientWrapper : IEventStore
    {
        public EventStoreClientWrapper()
        {
            //var client = EventStoreConnection.Create(new Uri())
        }
        public void Append(IEnumerable<CreateStreamEvent> createStreamEvent)
        {
            throw new NotImplementedException();
        }

        public void Append(CreateStreamEvent createStreamEvent)
        {
            throw new NotImplementedException();
        }

        public void AddNewProjection(Projection projection)
        {
            throw new NotImplementedException();
        }

        public void SubscribeToStream(string streamName, Action<StreamEvent> onEvent)
        {
            throw new NotImplementedException();
        }

        public void SubscribeToStream(string streamName, int position, Action<object> onEvent)
        {
            throw new NotImplementedException();
        }

        public List<StreamEvent> ReadStream(string streamName)
        {
            throw new NotImplementedException();
        }

        public StreamPositions GetPosition(string eventStream)
        {
            throw new NotImplementedException();
        }
    }
}
