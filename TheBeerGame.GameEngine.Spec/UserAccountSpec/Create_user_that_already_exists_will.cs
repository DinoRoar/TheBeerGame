using System.Collections.Generic;
using TheBeerGame.EventStore;
using TheBeerGame.GameEngine.Accounts;
using Xunit;

namespace TheBeerGame.GameEngine.Spec.UserAccountSpec
{
    public class Create_user_that_already_exists_will : AggregateSpecification<CreateAccountHandler, CreateAccount>
    {
        private readonly CreateAccount _command = new CreateAccount("userName", "token");
        public override IEnumerable<Event> Given() => new List<Event>()
        {
            new UserAccountCreated(_command)
        };

        public override CreateAccount When() => _command;

        public override CreateAccountHandler CreateAggregateRoot() => new CreateAccountHandler();

        [Fact]
        public void Do_nothing()
        {
            var events = Whenxecute();
            Assert.Empty(events);
        }
    }
}