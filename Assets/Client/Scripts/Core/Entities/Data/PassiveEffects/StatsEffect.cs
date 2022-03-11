using Core.Entities.Interfaces;
using UnityEngine;

namespace Core.Entities.Data.PassiveEffects
{
    [CreateAssetMenu(fileName = "New Stats Effect", menuName = "PassiveEffects/Stats Effect", order = 1)]
    public class StatsEffect : PassiveEffect
    {
        [SerializeField] private Stats _stats;

        public override void Disable(Entity entity)
        {
            entity.Remove(_stats);
        }
        public override void Enable(Entity entity)
        {
            entity.Add(_stats);
        }
    }
}