namespace TheBeerGame.GameEngine
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool Validate(string password, string hashedPassword);
    }
}