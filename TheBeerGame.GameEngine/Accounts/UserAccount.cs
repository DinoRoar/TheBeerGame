namespace TheBeerGame.GameEngine.Accounts
{
    public class UserAccount
    {
        public UserAccount(string auth0Id, string userName)
        {
            Auth0Id = auth0Id;
            UserName = userName;
            
        }
        public string Auth0Id { get; }
        public string UserName { get; }
    }
}