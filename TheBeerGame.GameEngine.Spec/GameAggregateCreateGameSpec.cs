using System.Collections.Generic;
using System.Linq;
using Serilog;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;

namespace TheBeerGame.GameEngine.Spec
{
    public class GameAggregateCreateGameSpec : AggregateSpecification<GameLobbyAggregate, CreateGame>
    {
        private readonly ILogger _output;

        public GameAggregateCreateGameSpec(ITestOutputHelper helper)
        {
            _output = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(helper, LogEventLevel.Verbose)
                .CreateLogger();

        }
        public override IEnumerable<Event> Given()
        {
            return new List<Event>();
        }

        public override CreateGame When()
        {
            return new CreateGame();
        }

        public override GameLobbyAggregate CreateAggregateRoot()
        {
            return new GameLobbyAggregate(_output);
        }


        [Fact]
        public void Create_Game_When_No_History()
        {
            Assert.Null(Exception);
            Assert.Single(Result);
            var e = Result.First();
        }
    }
}
