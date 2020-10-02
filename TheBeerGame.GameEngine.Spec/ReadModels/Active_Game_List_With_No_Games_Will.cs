using System.Collections.Generic;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using TheBeerGame.EventStore;
using TheBeerGame.GameEngine.ReadModels;
using Xunit;
using Xunit.Abstractions;

namespace TheBeerGame.GameEngine.Spec.ReadModels
{
    public class Active_game_list_with_no_games_will : InMemoryReadModelSpec<ActiveGameList>
    {
        private readonly Logger _logger;

        public Active_game_list_with_no_games_will(ITestOutputHelper helper)
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(helper, LogEventLevel.Verbose)
                .CreateLogger();
        }

        public override IEnumerable<Event> Given()
        {
            return new List<Event>();
        }

        public override IEnumerable<Event> When()
        {
            return new List<Event>();
        }

        public override ActiveGameList Factory()
        {
            return new ActiveGameList(_logger);
        }

        [Fact]
        public void Have_No_Games()
        {
            Assert.Empty(Whenecute().Games);
        }
    }
}
