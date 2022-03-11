using Core.Entities.Interfaces;
using UnityEngine;

namespace Core.Entities.Data.PassiveEffects
{
    [CreateAssetMenu(fileName = "New Passive Collection", menuName = "PassiveEffects/Passive Collection", order = 0)]
    public class PassiveCollection : PassiveEffect, IPassiveEffect
    {
        [SerializeField] private PassiveEffect[] _effects;

        public override void Disable(Entity entity)
        {
            foreach (var effect in _effects)
                effect.Disable(entity);
        }
        public override void Enable(Entity entity)
        {
            foreach (var effect in _effects)
                effect.Enable(entity);
        }
    }
}