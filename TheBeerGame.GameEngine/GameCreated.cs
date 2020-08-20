namespace TheBeerGame.GameEngine
{
    public class GameCreated : Event
    {
        public GameCreated(CreateGame command) : base(command)
        {

        }
    }
}