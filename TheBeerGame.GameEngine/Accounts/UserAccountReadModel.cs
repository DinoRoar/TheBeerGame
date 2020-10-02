using System.Collections.Generic;
using Serilog;


namespace TheBeerGame.GameEngine.Accounts
{
    public class UserAccountReadModel : InMemoryReadModel, IApply<UserAccountCreated>
    {
        private readonly Dictionary<string, UserAccount> _accounts = new Dictionary<string, UserAccount>();

        public UserAccountReadModel(ILogger logger) : base(logger)
        {
        }

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
    }
}