using System;

namespace TheBeerGame.GameEngine
{
    public class GameLobbyAggregate : AggregateRoot
        , IHandle<CreateGame>
        , IApply<GameCreated>
    {
        private bool _gameCreated = false;

        public void Apply(GameCreated @event)
        {
            _gameCreated = true;
        }

        public void Handle(CreateGame command)
        {
            if (_gameCreated) throw new GameAlreadyCreatedException(command.GameId);
            var gameCreated = new GameCreated(command);
            Uncommitted.Add(gameCreated);
        }

        public class GameAlreadyCreatedException : Exception
        {
            public GameAlreadyCreatedException(string gameId) : base($"Game already created: {gameId}")
            {

            }
        }

        public GameLobbyAggregate(string id) : base("gameLobby", id)
        {
        }
    }
}