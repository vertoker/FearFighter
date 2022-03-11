namespace Core.Entities.Interfaces
{
    public interface IActiveSkill
    {
        public void Init(Entity entity);
        public void Enable();
        public void Disable();
    }
}