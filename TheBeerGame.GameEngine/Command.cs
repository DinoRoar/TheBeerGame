using Newtonsoft.Json;

namespace TheBeerGame.GameEngine
{
    public class Command : Message
    {
        public Command()
        {
        }

        [JsonConstructor]
        public Command(string id, string correlationId, string causationId) : base(id, correlationId, causationId)
        {
        }
    }
}