using System;

namespace TheBeerGame.GameEngine
{
    public class Player : AggregateRoot, IHandle<Login>
    {
        public void Handle(Login command)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(command.Password);
            Uncommitted.Add(new PlayerCreated(command, hashedPassword));
        }
    }
}