using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;

namespace TheBeerGame.GameEngine.Spec.RegisterLoginSpec
{
    public class Login_when_not_registered_will : AggregateSpecification<Player, Login>
    {
        public Login_when_not_registered_will(ITestOutputHelper helper)
        {
            new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(helper, LogEventLevel.Verbose)
                .CreateLogger();
        }
        public override IEnumerable<Event> Given() => 
            new List<Event>();

        public override Login When() => new Login("playerName", "password");

        public override Player CreateAggregateRoot()
        {
            return new Player();
        }

        [Fact]
        public void Create_player()
        {
            var events = Whenxecute();
            Assert.Single(events);
            var e = events.First();
            Assert.IsType<PlayerCreated>(e);
            var pc = (PlayerCreated) e;
            Assert.NotEqual("password", pc.PasswordHash);
            Assert.Equal("playerName", pc.Name);
        }

    }


}
