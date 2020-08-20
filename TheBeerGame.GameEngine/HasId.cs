using System;

namespace TheBeerGame.GameEngine
{
    public class HasId
    {
        public string GetId() => $"{this.GetType().Name}-{Guid.NewGuid()}";
    }
}