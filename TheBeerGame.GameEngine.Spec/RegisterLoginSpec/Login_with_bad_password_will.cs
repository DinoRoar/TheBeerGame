using System.Collections.Generic;
using System.Linq;
using Serilog;
using Serilog.Events;
using TheBeerGame.GameEngine.LoginMessages;
using Xunit;
using Xunit.Abstractions;

namespace TheBeerGame.GameEngine.Spec.RegisterLoginSpec
{
    public class Login_with_bad_password_will : AggregateSpecification<Player, Login>
    {
        public Login_with_bad_password_will(ITestOutputHelper helper)
        {
            new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(helper, LogEventLevel.Verbose)
                .CreateLogger();
        }

        public override IEnumerable<Event> Given() =>
            new List<Event>()
            {
                new PlayerCreated(
                    new Login("playerName", new Password(new MockPasswordHasher(), "password")),
                    "password")
            };

        public override Login When()
        {
            return new Login("playerName", new Password(new MockPasswordHasher(), "wrong"));
        }

        public override Player CreateAggregateRoot()
        {
            return new Player();
        }

        [Fact]
        public void Fail()
        {
            var events = Whenxecute();
            Assert.Single(events);
            var e = events.First();
            Assert.IsType<LoginFailed>(e);
        }
    }
}