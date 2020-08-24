namespace TheBeerGame.GameEngine.Spec.RegisterLoginSpec
{
    public class MockPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public bool Validate(string password, string hashedPassword)
        {
            return password == hashedPassword;
        }
    }
}