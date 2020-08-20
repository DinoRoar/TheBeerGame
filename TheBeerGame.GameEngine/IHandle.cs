using System.Collections;

namespace TheBeerGame.GameEngine
{
    public interface IHandle<in TCommand> where TCommand : Command
    {
        public void Handle(TCommand command);
    }
}
