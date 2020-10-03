using System;
using Newtonsoft.Json;

namespace TheBeerGame.EventStore
{
    public class Message : HasId
    {
        public string Id { get; }
        public string CorrelationId { get; }
        public string CausationId { get; }

        public DateTime CreatedOn { get; }

        public string Type => this.GetType().Name;

        public Message()
        {
            Id = GetId();
            CorrelationId = Id;
            CausationId = Id;
            CreatedOn = DateTime.Now;
        }

        public Message(Message lastMessage)
        {
            Id = GetId();
            CorrelationId = lastMessage.CorrelationId;
            CausationId = lastMessage.Id;
            CreatedOn = DateTime.Now;
        }

        [JsonConstructor]
        public Message(string id, string correlationId, string causationId, DateTime createdOn)
        {
            Id = id;
            CorrelationId = correlationId;
            CausationId = causationId;
            CreatedOn = createdOn;
        }
    }
}