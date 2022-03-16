using Core.Entities.Data.PassiveEffects;
using Core.Entities.Interfaces;
using Core.Entities.Data;
using Common;

using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace Core.Entities
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] private Stats _baseStats;
        [SerializeField] private ArmorSetData _armorSlot;
        [SerializeField] private List<IItem> _items = new List<IItem>();

        [SerializeField] private List<PassiveEffect> _effects;
        [SerializeField] private Stats _passiveStats = new Stats();

        [SerializeField] private List<IActiveSkill> _skills;

        [SerializeField] public Stats ActiveStats { get; private set; }

        [SerializeField] private int activeHealth;
        private UnityEvent<int, int> _healthUpdateEvent = new UnityEvent<int, int>();
        private UnityEvent _deathEvent = new UnityEvent();

        public event UnityAction<int, int> HealthUpdateEvent 
        {
            add => _healthUpdateEvent.AddListener(value);
            remove => _healthUpdateEvent.RemoveListener(value);
        }
        public event UnityAction DeathEvent 
        {
            add => _deathEvent.AddListener(value);
            remove => _deathEvent.RemoveListener(value);
        }

        private void OnDisable()
        {
            DisableEffects();
        }
        private void OnEnable()
        {
            activeHealth = int.MaxValue;//Rework this
            EnableEffects();
        }

        public void Add(Stats stats)
        {
            _passiveStats += stats;
        }
        public void Add(PassiveCollection passiveEffect)
        {
            _effects.Add(passiveEffect);
            passiveEffect.Enable(this);
            UpdateStats();
        }
        public void Remove(Stats stats)
        {
            _passiveStats -= stats;
        }
        public void Remove(PassiveCollection passiveEffect)
        {
            if (_effects.Remove(passiveEffect))
            {
                passiveEffect.Disable(this);
                UpdateStats();
            }
        }

        public void UpdateStats()
        {
            List<Stats> stats = new List<Stats>
            {
                _baseStats,
                _armorSlot.GetStats(),
                _passiveStats
            };
            foreach (var item in _items)
                stats.Add(item.GetStats());

            Stats activeStats = Stats.Combine(stats.ToArray());
            activeStats.Normalize();

            NormalizeHealth(ActiveStats == null ? int.MaxValue : ActiveStats.Health, activeStats.Health);
            ActiveStats = activeStats;
        }

        public void RefreshPassiveEffect()
        {
            DisableEffects();
            EnableEffects();
        }
        private void DisableEffects()
        {
            foreach (var effect in _effects)
                effect.Disable(this);
            UpdateStats();
        }
        private void EnableEffects()
        {
            foreach (var effect in _effects)
                effect.Enable(this);
            UpdateStats();
        }

        public void Damage(StatsDamage statsDamage)
        {
            int damage = statsDamage.Damage;
            if (Random.Range(0, 101) <= ActiveStats.CritChance)
            {
                damage *= ActiveStats.CritAmplifier;
            }
            damage = (int)(damage * Formulas.ArmorResist(ActiveStats.Armor));

            if (damage >= activeHealth)
            {
                activeHealth = 0;
                _healthUpdateEvent.Invoke(activeHealth, ActiveStats.Health);
                _deathEvent.Invoke();
            }
            else
            {
                activeHealth -= damage;
                _healthUpdateEvent.Invoke(activeHealth, ActiveStats.Health);
            }
        }
        public void Heal(int heal)
        {
            activeHealth += heal;
            if (activeHealth > ActiveStats.Health)
            {
                activeHealth = ActiveStats.Health;
            }
            _healthUpdateEvent.Invoke(activeHealth, ActiveStats.Health);
        }

        private void NormalizeHealth(int oldMaxHealth, int newMaxHealth)
        {
            float progress = (float)activeHealth / oldMaxHealth;
            activeHealth = (int)(progress * newMaxHealth);
            _healthUpdateEvent.Invoke(activeHealth, newMaxHealth);
        }
    }
}