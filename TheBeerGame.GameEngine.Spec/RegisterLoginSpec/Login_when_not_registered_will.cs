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
    public class Login_when_not_created_will : AggregateSpecification<Player, Login>
    {
        public Login_when_not_created_will(ITestOutputHelper helper)
        {
            new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(helper, LogEventLevel.Verbose)
                .CreateLogger();
        }
        public override IEnumerable<Event> Given() => new List<Event>();

        public override Login When() => new Login("playerName", new Password(new MockPasswordHasher(), "password"));

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
            Assert.Equal("password", pc.PasswordHash);
            Assert.Equal("playerName", pc.Name);
        }
    }

    public class MockPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public bool Validate(string password, string hashedPassword)
        {
            return password == hashedPassword;
        }
    }

    public class Login_when_created_will : AggregateSpecification<Player, Login>
    {
        public Login_when_created_will(ITestOutputHelper helper)
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
            return new Login("playerName", new Password(new MockPasswordHasher(), "password"));
        }

        public override Player CreateAggregateRoot()
        {
            return new Player();
        }

        [Fact]
        public void Succeed()
        {
            var events = Whenxecute();
            Assert.Single(events);
            var e = events.First();
            Assert.IsType<LoginSucceeded>(e);
        }
    }

 
}
