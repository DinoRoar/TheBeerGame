using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using TheBeerGame.EventStore;

namespace TheBeerGame.GameEngine.Accounts
{
    public class CreateAccount : Command
    {
        public CreateAccount([NotNull] string userName, [NotNull] string token)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        [JsonConstructor]
        public CreateAccount(string id, string correlationId, string causationId, string userName, string token) : base(id, correlationId, causationId)
        {
            UserName = userName;
            Token = token;
        }

        public string UserName { get; }
        public string Token { get; }
    }
}