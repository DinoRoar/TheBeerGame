namespace TheBeerGame.GameEngine
{
    public class Login : Command
    {
        public string PlayerName { get; }
        public Password Password { get; }


        public Login(string playerName, Password password)
        {
            PlayerName = playerName;
            Password = password;
        }
    }
}