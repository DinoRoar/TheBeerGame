using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using Serilog.Events;
using TheBeerGame.EventStore;
using Xunit;
using Xunit.Abstractions;

namespace TheBeerGame.GameEngine.Spec.GameAggregateSpecs
{
    public class Game_aggregate_with_no_events_will : AggregateSpecification<GameLobbyAggregate, CreateGame>
    {
        private readonly ILogger _output;

        public Game_aggregate_with_no_events_will(ITestOutputHelper helper)
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
            return new CreateGame("gameId");
        }

        public override GameLobbyAggregate CreateAggregateRoot()
        {
            return new GameLobbyAggregate(DateTime.Today.ToShortDateString());
        }


        [Fact]
        public void Successfully_Create_Game()
        {
            var events = Whenxecute();
            var e = events.First();
            Assert.IsType<GameCreated>(e);
            var gc = (GameCreated) e;
            Assert.Equal("gameId",gc.GameId);
        }
    }
}
