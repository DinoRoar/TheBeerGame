using System.Linq;
using TheBeerGame.EventStore;
using TheBeerGame.GameEngine;
using TheBeerGame.GameEngine.LoginMessages;

namespace TheBeerGame.Client.Data
{
    public class RegisterLoginAppService
    {
        private readonly IEventStore _eventStore;
        private readonly IPasswordHasher _hasher;

        public RegisterLoginAppService(IEventStore eventStore, IPasswordHasher hasher)
        {
            _eventStore = eventStore;
            _hasher = hasher;
        }

        public LoginResult RegisterLogin(string userName, string password)
        {
            LoginResult retVal = new LoginResult(false);
            var p = new Password(_hasher, password);

            var streamName = $"user-{userName}";
            var events = _eventStore.ReadStream(streamName);
            var agg = new Player(userName);
            agg.Apply(events);

            agg.Handle(new Login(userName, p));
            var uncommitted = agg.GetEventsToWrite();

            var @event = uncommitted.Events.First();
            if (@event.GetType() == typeof(PlayerCreated))
            {
                retVal = new LoginResult(true);
            }
            _eventStore.Append(uncommitted);

            return retVal;
        }
    }

    public class LoginResult
    {
        public bool Result { get; }

        public LoginResult(bool result)
        {
            Result = result;
            throw new System.NotImplementedException();
        }
    }


    public class RegisterLoginDomainService
    {
        public RegisterLoginDomainService()
        {

        }

        public RegisterLoginDomainService(IEventStore eventStore, IPasswordHasher hasher)
        {

        }

        public void RegisterLogin()
        {

        }
    }
}
