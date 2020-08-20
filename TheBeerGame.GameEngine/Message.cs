using Newtonsoft.Json;

namespace TheBeerGame.GameEngine
{
    public class Message : HasId
    {
        public string Id { get; }

        public string CorrelationId { get; }
        public string CausationId { get; }

        public string Type => this.GetType().Name;

        public Message()
        {
            Id = GetId();
            CorrelationId = Id;
            CausationId = Id;
        }

        public Message(Message lastMessage)
        {
            Id = GetId();
            CorrelationId = lastMessage.CorrelationId;
            CausationId = lastMessage.Id;
        }

        [JsonConstructor]
        public Message(string id, string correlationId, string causationId)
        {
            Id = id;
            CorrelationId = correlationId;
            CausationId = causationId;
        }
    }
}