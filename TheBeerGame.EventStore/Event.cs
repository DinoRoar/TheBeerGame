using System;
using Newtonsoft.Json;

namespace TheBeerGame.EventStore
{
    public class Event : Message
    {
        public Event(Message cause) : base(cause)
        {
        }

        [JsonConstructor]
        public Event(string id, string correlationId, string causationId, DateTime createdOn) : base(id, correlationId, causationId, createdOn)
        {
        }

        
    }
}