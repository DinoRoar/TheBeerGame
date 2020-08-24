namespace TheBeerGame.GameEngine
{
    public class BCryptPasswordAdapter : IPasswordHasher
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public bool Validate(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.Verify(password, hashedPassword, true);

    }
}