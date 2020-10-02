using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheBeerGame.EventStore;
using TheBeerGame.GameEngine;
using TheBeerGame.GameEngine.Accounts;

namespace TheBeerGame.Client.Data
{
    public class AccountService
    {
        private readonly IEventStore _eventStore;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IEventStore eventStore, ILogger<AccountService> logger)
        {
            _eventStore = eventStore;
            _logger = logger;
        }

        public ResultOrError<GameCreated> CreateGame(string gameId)
        {
            _logger.LogDebug("creating game {gameId}", gameId);
            var correlationId = Guid.NewGuid().ToString();
            return new ResultOrError<GameCreated>(new GameCreated(gameId, "id", correlationId, correlationId));
        }

        public Task<Option<UserAccount>> HandleUserLoggedIn(string oAuthId)
        {
            _logger.LogDebug("handling login {oAuthId}", oAuthId);

            var events = _eventStore.ReadStream($"userAccount-{oAuthId}");
            

            return Task.FromResult(new Option<UserAccount>());
        }
    }


  


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
