using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Entities.Data
{
    [System.Serializable]
    public class Stats
    {
#if UNITY_EDITOR
        private const string healthTooltip = "���� - �������� �� ���������� �������� � ���������";
        private const string speedTooltip = "�������� - �������� �� �������� ������������ ���������";
        private const string armorTooltip = "����� - �������� �� ������������� ����� ��������� ";
        private const string critChanceTooltip = "���� ������������ ����� - ���������� ������� ���� ������������ ����� (�� 0 �� 100)";
        private const string critAmpliifierTooltip = "���� ������������ ����� - ���������� ����, ������� ������� ���� (����� ���� �������������)";
#endif

#if UNITY_EDITOR
        [Tooltip(healthTooltip)]
#endif
        [SerializeField] private int _health;
#if UNITY_EDITOR
        [Tooltip(speedTooltip)]
#endif
        [SerializeField] private int _speed;
#if UNITY_EDITOR
        [Tooltip(armorTooltip)]
#endif
        [SerializeField] private int _armor;
#if UNITY_EDITOR
        [Tooltip(critChanceTooltip)]
#endif
        [SerializeField] [Range(0, 100)] private int _critChance;
#if UNITY_EDITOR
        [Tooltip(critAmpliifierTooltip)]
#endif
        [SerializeField] private int _critAmplifier;

        public int Health => _health;
        public int Speed => _speed;
        public int Armor => _armor;
        public int CritChance => _critChance;
        public int CritAmplifier => _critAmplifier;

        public Stats(int health, int speed, int armor, int critChance, int critAmplifier)
        {
            _health = health;
            _speed = speed;
            _armor = armor;
            _critChance = critChance;
            _critAmplifier = critAmplifier;
        }
        public Stats()
        {
            _health = 1;
            _speed = 0;
            _armor = 0;
            _critChance = 0;
            _critAmplifier = 0;
        }

        public void Normalize()
        {
            _health = Mathf.Max(_health, 1);
            _speed = Mathf.Max(_speed, 0);
            _critChance = Mathf.Clamp(_critChance, 1, 100);
            _critAmplifier = Mathf.Max(_critAmplifier, 1);
        }
        public static Stats Combine(params Stats[] stats)
        {
            int health = stats[0].Health;
            int speed = stats[0].Speed;
            int armor = stats[0].Armor;
            int critChance = stats[0].CritChance;
            int critAmplifier = stats[0].CritAmplifier;

            for (int i = 1; i < stats.Length; i++)
            {
                health += stats[i].Health;
                speed += stats[i].Speed;
                armor += stats[i].Armor;
                critChance += stats[i].CritChance;
                critAmplifier += stats[i].CritAmplifier;
            }

            return new Stats(health, speed, armor, critChance, critAmplifier);
        }

        public static Stats operator +(Stats stats1, Stats stats2)
        {
            int health = stats1.Health + stats2.Health;
            int speed = stats1.Speed + stats2.Speed;
            int armor = stats1.Armor + stats2.Armor;
            int critChance = stats1.CritChance + stats2.CritChance;
            int critAmplifier = stats1.CritAmplifier + stats2.CritAmplifier;
            return new Stats(health, speed, armor, critChance, critAmplifier);
        }
        public static Stats operator -(Stats stats1, Stats stats2)
        {
            int health = stats1.Health - stats2.Health;
            int speed = stats1.Speed - stats2.Speed;
            int armor = stats1.Armor - stats2.Armor;
            int critChance = stats1.CritChance - stats2.CritChance;
            int critAmplifier = stats1.CritAmplifier - stats2.CritAmplifier;
            return new Stats(health, speed, armor, critChance, critAmplifier);
        }
    }
}