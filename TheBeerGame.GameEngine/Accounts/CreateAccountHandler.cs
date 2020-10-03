namespace TheBeerGame.GameEngine.Accounts
{
    public class CreateAccountHandler : AggregateRoot,
        IHandle<CreateAccount>
    {
        private Option<UserAccount> _user = new Option<UserAccount>();

        public CreateAccountHandler(string id) : base("userAccount", id)
        {
        }

        public void Handle(CreateAccount command)
        {
            if (!_user.HasValue)
            {
                Uncommitted.Add(new UserAccountCreated(command));
            }
        }

        public void Apply(UserAccountCreated @event)
        {
            _user = new Option<UserAccount>(new UserAccount(@event.UserName, @event.Token));
        }


    }
}