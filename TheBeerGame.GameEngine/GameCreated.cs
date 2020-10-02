using System.Collections.Generic;
using Newtonsoft.Json;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{
    public class GameCreated : Event
    {
        public GameCreated(CreateGame command) : base(command)
        {
            GameId = command.GameId;
        }

        [JsonConstructor]
        public GameCreated(string gameId, string id, string correlationId, string causationId) : base(id, correlationId, causationId)
        {
            GameId = gameId;
        }

        public string GameId { get; }
    }
}