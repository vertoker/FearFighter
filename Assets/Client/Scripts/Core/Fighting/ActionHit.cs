using AnimationSprite = Core.Animation.Transforms.Animation;
using Core.Entities.Data;
using UnityEngine;

namespace Core.Fighting
{
    [CreateAssetMenu(fileName = "New Hit", menuName = "Data/Hit")]
    public class ActionHit : ScriptableObject
    {
        [SerializeField] private AnimationSprite _hitAnimation;
        [SerializeField] private StatsDamage _statsDamage;
    }
}