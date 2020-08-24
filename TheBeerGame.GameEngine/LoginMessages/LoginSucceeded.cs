namespace TheBeerGame.GameEngine
{
    public class LoginSucceeded : Event
    {
        public LoginSucceeded(Message cause) : base(cause)
        {
        }

        public LoginSucceeded(string id, string correlationId, string causationId) : base(id, correlationId, causationId)
        {
        }
    }
}