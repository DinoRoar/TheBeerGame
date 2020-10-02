using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheBeerGame.EventStore;
using TheBeerGame.GameEngine;
using TheBeerGame.GameEngine.Accounts;

namespace TheBeerGame.Client.Data
{
    public class AccountService
    {
        private readonly IEventStore _eventStore;
        private readonly UserAccountReadModel _readModel;
        private readonly ILogger<AccountService> _logger;

        public AccountService(UserAccountReadModel readModel,IEventStore eventStore, ILogger<AccountService> logger)
        {
            _eventStore = eventStore;
            _readModel = readModel;
            _logger = logger;
        }

        public Task SetupUser(string oAuthId, string userName)
        {
            var agg = new CreateAccountHandler();
            var events = _eventStore.ReadStream(agg.BuildStreamName(oAuthId));
            agg.Apply(events);

            agg.Handle(new CreateAccount(userName, oAuthId));
            return Task.CompletedTask;
        }

        public Task<Option<UserAccount>> HandleUserLoggedIn(string oAuthId)
        {
            _logger.LogDebug("handling login {oAuthId}", oAuthId);

            return Task.FromResult(_readModel.GetAccount(oAuthId));
        }
    }
}