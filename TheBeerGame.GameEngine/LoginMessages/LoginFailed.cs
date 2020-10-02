using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine.LoginMessages
{
    public class LoginFailed : Event
    {
        public LoginFailed(Login command) : base(command)
        {
            
        }
    }
}