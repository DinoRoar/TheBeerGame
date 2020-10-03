using System;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine
{
    public class LoginSucceeded : Event
    {
        public LoginSucceeded(Message cause) : base(cause)
        {
        }

        public LoginSucceeded(string id, string correlationId, string causationId, DateTime createdOn) : base(id, correlationId, causationId, createdOn)
        {
        }
    }
}