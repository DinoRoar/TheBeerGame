namespace TheBeerGame.GameEngine
{
    public class Password
    {
        private readonly IPasswordHasher _hasher;
        public string DotNetIsRetardedAndWontLetMeNameThisSameAsClass { get; }

        public Password(IPasswordHasher hasher, string password)
        {
            _hasher = hasher;
            DotNetIsRetardedAndWontLetMeNameThisSameAsClass = password;
        }

        public bool Validate(string hashedPassword) => _hasher.Validate(DotNetIsRetardedAndWontLetMeNameThisSameAsClass, hashedPassword);

        public string HashPassword() => _hasher.HashPassword(DotNetIsRetardedAndWontLetMeNameThisSameAsClass);
    }
}