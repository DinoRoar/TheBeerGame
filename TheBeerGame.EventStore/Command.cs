using System;
using Newtonsoft.Json;

namespace TheBeerGame.EventStore
{
    public class Command : Message
    {
        public Command()
        {
        }

        [JsonConstructor]
        public Command(string id, string correlationId, string causationId, DateTime createdOn) : base(id, correlationId, causationId, createdOn)
        {
        }
    }
}