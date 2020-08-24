using Newtonsoft.Json;
using TheBeerGame.GameEngine.LoginMessages;

namespace TheBeerGame.GameEngine
{
    public class PlayerCreated : Event
    {
        public string PasswordHash { get; }
        public string Name { get; }

        public PlayerCreated(Login cause, string passwordHash) : base(cause)
        {
            Name = cause.PlayerName;
            PasswordHash = passwordHash;
        }

        [JsonConstructor]
        public PlayerCreated(string id, string correlationId, string causationId, string name, string passwordHash) : base(id, correlationId, causationId)
        {
            Name = name;
            PasswordHash = passwordHash;
        }
    }
}