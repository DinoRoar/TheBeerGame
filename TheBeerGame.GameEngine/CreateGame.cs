namespace TheBeerGame.GameEngine
{
    public class CreateGame : Command
    {
        public CreateGame(string gameId)
        {
            GameId = gameId;
        }

        public string GameId { get; }
    }
}