using System;
using System.Diagnostics.CodeAnalysis;

namespace TheBeerGame.GameEngine
{
    public class Option<T>
    {
        public Option([NotNull] T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            HasValue = true;
        }

        public Option()
        {
            HasValue = false;
        }

        public T Value { get; } = default!;
        public bool HasValue { get; }
    }
}