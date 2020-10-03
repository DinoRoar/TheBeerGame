using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        public async Task Append(EventsToWrite eventsToWrite)
        {
           
            foreach (var @event in eventsToWrite.Events)
            {
                var eventBytes = UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));
                var eventMetaData = UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new EventMetaData(@event)));
                var eventData = new EventData(Guid.NewGuid(),@event.Type,true,  eventBytes, eventMetaData);
                await _client.AppendToStreamAsync(eventsToWrite.StreamName, eventsToWrite.NextEventPosition, eventData);
            }
        }

        private EventMetaData ToMetaData(Event @event)
        {
            throw new NotImplementedException();
        }

        public Task Append(CreateStreamEvent createStreamEvent)
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

    public class EventMetaData
    {
        public EventMetaData()
        {
        }

        public EventMetaData(Event @event)
        {
            Id = @event.Id;
            CorrelationId = @event.CorrelationId;
            CausationId = @event.CausationId;
            CreatedOn = @event.CreatedOn;
        }

        public DateTime CreatedOn { get; set; }

        public string CausationId { get; set; }

        public string CorrelationId { get; set; }

        public string Id { get; set; }
    }
}
