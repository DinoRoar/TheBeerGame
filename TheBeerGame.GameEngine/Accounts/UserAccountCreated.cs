﻿using Newtonsoft.Json;
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
        public UserAccountCreated(string id, string correlationId, string causationId, string token, string userName)
            : base(id, correlationId, causationId)
        {
            Token = token;
            UserName = userName;
        }

        public string Token { get; }

        public string UserName { get; }
    }
}