using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using TheBeerGame.EventStore;
using TheBeerGame.GameEngine.Accounts;
using Xunit;
using Xunit.Abstractions;

namespace TheBeerGame.GameEngine.Spec.UserAccountSpec
{
    public class User_account_uninitialized_will_be_empty_option :  InMemoryReadModelSpec<UserAccountReadModel>
    {
        private readonly Logger _logger;

        public User_account_uninitialized_will_be_empty_option(ITestOutputHelper helper)
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(helper, LogEventLevel.Verbose)
                .CreateLogger();
        }
        public override IEnumerable<Event> Given() => new List<Event>();

        public override IEnumerable<Event> When() => new List<Event>();

        public override UserAccountReadModel Factory() => new UserAccountReadModel(_logger);

        [Fact]
        public void WillReturnEmptyOptionIfAccountDoesNotExist()
        {
            Assert.False(Whenecute().GetAccount("auth0Name").HasValue);
        }
    }

    public class User_account_with_account_will : InMemoryReadModelSpec<UserAccountReadModel>
    {
        private readonly Logger _logger;

        public User_account_with_account_will(ITestOutputHelper helper)
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(helper, LogEventLevel.Verbose)
                .CreateLogger();
        }
        public override IEnumerable<Event> Given() => new List<Event>()
        {
            new UserAccountCreated(new CreateAccount("userName", "auth0Name") )
        };

        public override IEnumerable<Event> When() => new List<Event>();

        public override UserAccountReadModel Factory() => new UserAccountReadModel(_logger);

        [Fact]
        public void Return_the_account()
        {
            var accountOption = Whenecute().GetAccount("auth0Name");
            Assert.True(accountOption.HasValue);
            Assert.Equal("userName", accountOption.Value.UserName);
            Assert.Equal("auth0Name", accountOption.Value.Auth0Id);
        }
    }
}
