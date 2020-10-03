using System;
using Newtonsoft.Json;
using TheBeerGame.EventStore;
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
        public PlayerCreated(string id, string correlationId, string causationId, string name, string passwordHash, DateTime createdOn) : base(id, correlationId, causationId, createdOn)
        {
            Name = name;
            PasswordHash = passwordHash;
        }
    }
}