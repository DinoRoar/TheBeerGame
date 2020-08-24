using System.Net.Sockets;
using TheBeerGame.GameEngine.LoginMessages;
using static System.String;


namespace TheBeerGame.GameEngine
{
    public class Player : AggregateRoot
        , IHandle<Login>
        , IApply<PlayerCreated>
    {
        private bool _registered;
        private string _password = Empty;

        public void Handle(Login command)
        {
            if (!_registered)
            {
                var hashedPassword = command.Password.HashPassword();
                Uncommitted.Add(new PlayerCreated(command, hashedPassword));
            }
            else
            {
                if (command.Password.Validate(_password))
                {
                    Uncommitted.Add(new LoginSucceeded(command));
                }
                else
                {
                    Uncommitted.Add(new LoginFailed(command));
                }
            }
        }

        public void Apply(PlayerCreated @event)
        {
            _registered = true;
            _password = @event.PasswordHash;
        }
    }
}