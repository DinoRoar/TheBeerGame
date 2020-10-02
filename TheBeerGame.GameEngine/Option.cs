using System.Diagnostics.CodeAnalysis;

namespace TheBeerGame.GameEngine
{
    public class Option<T>
    {
        public Option([NotNull] T value)
        {
            Value = value;
            HasValue = true;
        }

        public Option()
        {
            HasValue = false;
        }

        public T Value { get; }
        public bool HasValue { get; }
    }
}