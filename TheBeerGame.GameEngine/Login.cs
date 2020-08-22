namespace TheBeerGame.GameEngine
{
    public class Login : Command
    {
        public string PlayerName { get; }
        public string Password { get; }

        public Login(string playerName, string password)
        {
            PlayerName = playerName;
            Password = password;
        }
    }
}