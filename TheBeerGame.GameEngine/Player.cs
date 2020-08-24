using System.Net.Sockets;
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

    public class LoginFailed : Event
    {
        public LoginFailed(Login command) : base(command)
        {
            
        }
    }

    public class LoginSucceeded : Event
    {
        public LoginSucceeded(Message cause) : base(cause)
        {
        }

        public LoginSucceeded(string id, string correlationId, string causationId) : base(id, correlationId, causationId)
        {
        }
    }

    public class BCryptPasswordAdapter : IPasswordHasher
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public bool Validate(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.Verify(password, hashedPassword, true);

    }

    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool Validate(string password, string hashedPassword);
    }

    public class Password
    {
        private readonly IPasswordHasher _hasher;
        public string DotNetIsRetardedAndWontLetMeNameThisSameAsClass { get; }

        public Password(IPasswordHasher hasher, string password)
        {
            _hasher = hasher;
            DotNetIsRetardedAndWontLetMeNameThisSameAsClass = password;
        }

        public bool Validate(string hashedPassword) => _hasher.Validate(DotNetIsRetardedAndWontLetMeNameThisSameAsClass, hashedPassword);

        public string HashPassword() => _hasher.HashPassword(DotNetIsRetardedAndWontLetMeNameThisSameAsClass);
    }
}