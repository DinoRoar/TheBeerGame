using System;

namespace TheBeerGame.EventStore
{
    public class HasId
    {
        public string GetId() => $"{this.GetType().Name}-{Guid.NewGuid()}";
    }
}