namespace TheBeerGame.GameEngine
{
    public interface IApply<in T>
    {
        void Apply(T @event);
    }
}