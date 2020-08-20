using Serilog;

namespace TheBeerGame.GameEngine
{
    public class GameLobbyAggregate : AggregateRoot, IHandle<CreateGame>
    {
        public void Handle(CreateGame command)
        {
            var gameCreated = new GameCreated(command);
            Uncommitted.Add(gameCreated);
        }

        public GameLobbyAggregate(ILogger logger) : base(logger)
        {
        }
    }
}