using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Entities.Data
{
    [System.Serializable]
    public class StatsDamage
    {
#if UNITY_EDITOR
        private const string damageTooltip = "������� ���� - �������� �� ������� ���� ���������";
#endif

#if UNITY_EDITOR
        [Tooltip(damageTooltip)]
#endif
        [SerializeField] private int _minDamage;
#if UNITY_EDITOR
        [Tooltip(damageTooltip)]
#endif
        [SerializeField] private int _maxDamage;

        public int MinDamage => _minDamage;
        public int MaxDamage => _maxDamage;
        public int Damage => _minDamage + (int)((_maxDamage - _minDamage) * Random.value);

        public StatsDamage(int minDamage, int maxDamage)
        {
            _minDamage = minDamage;
            _maxDamage = maxDamage;
        }
        public StatsDamage()
        {
            _minDamage = 0;
            _maxDamage = 0;
        }

        public void Normalize()
        {
            _minDamage = Mathf.Max(_minDamage, 0);
            _maxDamage = Mathf.Max(_maxDamage, 0);
        }
        public static StatsDamage Combine(params StatsDamage[] stats)
        {
            int minDamage = stats[0].MinDamage;
            int maxDamage = stats[0].MaxDamage;

            for (int i = 1; i < stats.Length; i++)
            {
                minDamage += stats[i].MinDamage;
                maxDamage += stats[i].MaxDamage;
            }

            return new StatsDamage(minDamage, maxDamage);
        }

        public static StatsDamage operator +(StatsDamage stats1, StatsDamage stats2)
        {
            int minDamage = stats1.MinDamage + stats2.MinDamage;
            int maxDamage = stats1.MaxDamage + stats2.MaxDamage;
            return new StatsDamage(minDamage, maxDamage);
        }
        public static StatsDamage operator -(StatsDamage stats1, StatsDamage stats2)
        {
            int minDamage = stats1.MinDamage - stats2.MinDamage;
            int maxDamage = stats1.MaxDamage - stats2.MaxDamage;
            return new StatsDamage(minDamage, maxDamage);
        }
    }
}