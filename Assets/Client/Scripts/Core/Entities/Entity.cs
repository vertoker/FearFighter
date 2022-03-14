using Core.Entities.Data.PassiveEffects;
using Core.Entities.Interfaces;
using Core.Entities.Data;

using System.Collections.Generic;
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

        public Stats ActiveStats { get; private set; }

        private void OnDisable()
        {
            DisableEffects();
        }
        private void OnEnable()
        {
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

            ActiveStats = Stats.Combine(stats.ToArray());
            ActiveStats.Normalize();
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
    }
}