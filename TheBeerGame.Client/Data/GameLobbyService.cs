using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBeerGame.GameEngine;

namespace TheBeerGame.Client.Data
{
    public class GameLobbyService
    {
        public ResultOrError<GameCreated> CreateGame(string gameId)
        {
            var correlationId = Guid.NewGuid().ToString();
            return new ResultOrError<GameCreated>(new GameCreated(gameId, "id", correlationId, correlationId));
        }

        public Task<List<RunningGame>> GetRunningGames()
        {
            return Task.FromResult(new List<RunningGame>()
            {
                new RunningGame("game1")
            });
        }
    }

    public class RunningGame
    {
        public string Game { get; }

        public RunningGame(string game)
        {
            Game = game;
        }
    }
}
