using AnimationSprite = Core.Animation.Sprites.Animation;
using UnityEngine;

namespace Core.Fighting
{
    public class ActionHit : ScriptableObject
    {
        [SerializeField] private AnimationSprite _hitAnimation;
        [Header("Stats")]
        [SerializeField] private HitDamage _hitDamage;
    }
}