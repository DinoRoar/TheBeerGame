using System;
using Newtonsoft.Json;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine.Accounts
{
    public class UserAccountCreated : Event
    {
        public UserAccountCreated(CreateAccount command) : base(command)
        {
            UserName = command.UserName;
            Token = command.Token;
        }

        [JsonConstructor]
        public UserAccountCreated(string id, string correlationId, string causationId, string token, string userName, DateTime createdOn)
            : base(id, correlationId, causationId, createdOn)
        {
            Token = token;
            UserName = userName;
        }

        public string Token { get; }

        public string UserName { get; }
    }
}