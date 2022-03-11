namespace Core.Entities.Interfaces
{
    public interface IPassiveEffect
    {
        public void Enable(Entity entity);
        public void Disable(Entity entity);
    }
}