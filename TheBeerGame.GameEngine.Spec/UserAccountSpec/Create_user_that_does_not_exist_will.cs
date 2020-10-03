using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheBeerGame.EventStore;
using TheBeerGame.GameEngine.Accounts;
using Xunit;

namespace TheBeerGame.GameEngine.Spec.UserAccountSpec
{
    public class Create_user_that_does_not_exist_will : AggregateSpecification<CreateAccountHandler, CreateAccount>
    {
        public override IEnumerable<Event> Given() => new List<Event>();

        public override CreateAccount When() => new CreateAccount("userName", "token");

        public override CreateAccountHandler CreateAggregateRoot() => new CreateAccountHandler("token");

        [Fact]
        public void Successfully_create_user_account()
        {
            var events = Whenxecute();
            Assert.Single(events);

            var e = events.First();
            Assert.IsType<UserAccountCreated>(e);
            var userAccountCreated = (UserAccountCreated) e;
            Assert.Equal("userName", userAccountCreated.UserName);
            Assert.Equal("token", userAccountCreated.Token);
        }
    }
}
