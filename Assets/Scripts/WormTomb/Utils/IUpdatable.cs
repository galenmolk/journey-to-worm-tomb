namespace WormTomb.Utils
{
    public interface IUpdatable
    {
        public enum Type
        {
            Regular = 0,
            Fixed = 1
        }
        
        bool AlwaysUpdate { get; }
        
        Type UpdateType { get; }
        
        void ExecuteUpdate();
    }
}
