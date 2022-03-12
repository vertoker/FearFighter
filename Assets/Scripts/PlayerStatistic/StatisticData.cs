using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerStatistic
{
    public abstract class StatisticData
    {
        public static event Action StatisticChangedEvent;

        protected virtual void OnStatsChanged()
        {
            StatisticChangedEvent?.Invoke();
        }

        /// <summary>
        /// Объект регистрируется на необходимые ему события
        /// </summary>
        protected abstract void Registrate();

    }
}