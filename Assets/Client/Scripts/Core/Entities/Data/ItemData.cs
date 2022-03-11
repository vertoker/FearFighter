using Core.Entities.Interfaces;
using UnityEngine;

namespace Core.Entities.Data
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Data/Item", order = 0)]
    public class ItemData : ScriptableObject, IItem
    {
        [SerializeField] private Stats _stats;

        public Stats GetStats()
        {
            return _stats;
        }
        public IPassiveEffect GetPassiveEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}