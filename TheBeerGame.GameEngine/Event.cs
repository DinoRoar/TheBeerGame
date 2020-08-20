using Newtonsoft.Json;

namespace TheBeerGame.GameEngine
{
    public class Event : Message
    {
        public Event(Message cause) : base(cause)
        {
        }

        [JsonConstructor]
        public Event(string id, string correlationId, string causationId) : base(id, correlationId, causationId)
        {
        }
    }
}