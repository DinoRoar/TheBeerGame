using System.Collections.Generic;
using TheBeerGame.EventStore;
using TheBeerGame.GameEngine.ReadModels;

namespace TheBeerGame.GameEngine.Spec
{
    public abstract class InMemoryReadModelSpec<TReadModel> where TReadModel : InMemoryReadModel
    {
        public abstract IEnumerable<Event> Given();
        public abstract IEnumerable<Event> When();
        public abstract TReadModel Factory();

        public TReadModel Whenecute()
        {
            var rm = Factory();
            rm.Apply(Given());
            rm.Apply(When());
            return rm;
        }
    }
}