using Core.Entities.Interfaces;
using UnityEngine;

namespace Core.Entities.Data.PassiveEffects
{
    public class PassiveEffect : ScriptableObject, IPassiveEffect
    {
        public virtual void Disable(Entity entity)
        {

        }
        public virtual void Enable(Entity entity)
        {

        }
    }
}