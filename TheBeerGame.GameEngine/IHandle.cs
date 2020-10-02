using System.Collections;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{
    public interface IHandle<in TCommand> where TCommand : Command
    {
        public void Handle(TCommand command);
    }
}
