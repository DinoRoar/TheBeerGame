using System.Collections.Generic;
using TheBeerGame.EventStore;


namespace TheBeerGame.GameEngine.Accounts
{
    public class UserAccountReadModel : SubscribedProjection, IApply<UserAccountCreated>
    {
        private readonly Dictionary<string, UserAccount> _accounts = new Dictionary<string, UserAccount>();

        public Option<UserAccount> GetAccount(string auth0Name)
        {
            return _accounts.ContainsKey(auth0Name) 
                ? new Option<UserAccount>(_accounts[auth0Name]) 
                : new Option<UserAccount>();
        }

        public void Apply(UserAccountCreated @event)
        {
            _accounts.Add(@event.Token, new UserAccount(@event.Token, @event.UserName));
        }

        public UserAccountReadModel(IEventStore eventStore) : base(eventStore, "ca-userAccount")
        {
        }
    }
}