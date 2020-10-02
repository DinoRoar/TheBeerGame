using System.Collections.Generic;
using Serilog;
using Serilog.Events;
using TheBeerGame.EventStore;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable InconsistentNaming

namespace TheBeerGame.GameEngine.Spec.GameAggregateSpecs
{
    public class Create_game_when_already_created_will : AggregateSpecification<GameLobbyAggregate, CreateGame>
    {
        private readonly ILogger _output;

        public Create_game_when_already_created_will(ITestOutputHelper helper):base()
        {
            _output = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(helper, LogEventLevel.Verbose)
                .CreateLogger();

        }
        public override IEnumerable<Event> Given()
        {
            return new List<Event>()
            {
                new GameCreated("gameId", "id", "correlationId", "causationId")
            };
        }

        public override CreateGame When()
        {
            return new CreateGame("gameId");
        }

        public override GameLobbyAggregate CreateAggregateRoot()
        {
            return new GameLobbyAggregate();
        }


        [Fact]
        public void Throw_exception()
        {
            Assert.Throws<GameLobbyAggregate.GameAlreadyCreatedException>(Whenxecute);
        }
    }

}
