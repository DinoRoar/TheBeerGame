using System.Collections;
using System.Collections.Generic;
using Serilog;

namespace TheBeerGame.GameEngine.ReadModels
{
    public class ActiveGameList : InMemoryReadModel
    {
        
        public ActiveGameList(ILogger logger) : base(logger)
        {
        }

        public IEnumerable<GameListItem> Games { get; } = new List<GameListItem>();

        public class GameListItem
        {
        }
    }
}
