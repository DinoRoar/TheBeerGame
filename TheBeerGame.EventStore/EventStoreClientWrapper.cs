using System;
using System.Collections.Generic;
using EventStore.ClientAPI;
using Microsoft.Extensions.Logging;

//using EventStore.ClientAPI;

namespace TheBeerGame.EventStore
{
    public class EventStoreClientWrapper : IEventStore
    {
        private readonly IEventStoreConnection _client;

        public EventStoreClientWrapper(ILogger<EventStoreClientWrapper> logger)
        {
            _client = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:1113"));
            _client.Connected += (sender, args) =>
            {
                logger.LogInformation("Eventstore connected");
            };

            _client.ErrorOccurred += (sender, args) =>
            {
                logger.LogError(args.Exception, "eventstore error occured");
            };

            _client.AuthenticationFailed += (sender, args) =>
            {
                logger.LogError("Eventstore Authentication failed {reason}", args.Reason);
            };

            _client.Closed += (sender, args) =>
            {
                logger.LogInformation("Evenstore connection closed: {reason}", args.Reason);
            };

            _client.Disconnected += (sender, args) =>
            {
                logger.LogInformation("Eventstore disconnected: {reason}", args.RemoteEndPoint);
            };

            _client.Reconnecting += (sender, args) =>
            {
                logger.LogInformation("Eventstore reconnecting");
            };

            _client.ConnectAsync().Wait();
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
