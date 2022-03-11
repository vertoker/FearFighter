using Core.Entities.Interfaces;
using UnityEngine;

namespace Core.Entities.Data
{
    [CreateAssetMenu(fileName = "New Armor Set", menuName = "Data/Armor Set", order = 1)]
    public class ArmorSetData : ScriptableObject, IItem
    {
        [SerializeField] private Stats _stats;
        //Добавить данные анимации

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