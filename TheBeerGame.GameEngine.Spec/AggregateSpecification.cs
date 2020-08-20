using System;
using System.Collections.Generic;

namespace TheBeerGame.GameEngine.Spec
{
    public abstract class AggregateSpecification<TAggregate, TCommand>
        where TAggregate : AggregateRoot, IHandle<TCommand>
        where TCommand : Command
    {
        protected IEnumerable<Event> Result;
        protected Exception Exception;

        public abstract IEnumerable<Event> Given();
        public abstract TCommand When();
        public abstract TAggregate CreateAggregateRoot();

        protected AggregateSpecification()
        {
            try
            {
                var sut = CreateAggregateRoot();
                sut.Apply(Given());
                sut.Handle(When());
                Result = sut.GetUncommittedEvents();
            }
            catch (Exception ex)
            {
                Exception = ex;
            }
        }

    }
}