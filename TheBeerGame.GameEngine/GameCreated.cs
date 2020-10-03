using System;
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
        public GameCreated(string gameId, string id, string correlationId, string causationId, DateTime createdOn) : base(id, correlationId, causationId, createdOn)
        {
            GameId = gameId;
        }

        public string GameId { get; }
    }
}