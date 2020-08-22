using System;
using System.Collections.Generic;

namespace TheBeerGame.GameEngine.Spec
{
    public abstract class AggregateSpecification<TAggregate, TCommand>
        where TAggregate : AggregateRoot, IHandle<TCommand>
        where TCommand : Command
    {
        public abstract IEnumerable<Event> Given();
        public abstract TCommand When();
        public abstract TAggregate CreateAggregateRoot();

        public List<Event> Whenxecute()
        {
            var sut = CreateAggregateRoot();
            sut.Apply(Given());
            sut.Handle(When());
            return sut.GetUncommittedEvents();
        }
    }
}