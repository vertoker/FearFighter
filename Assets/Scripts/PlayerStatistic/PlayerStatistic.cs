using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace PlayerStatisticSystem
{
    public class PlayerStatistic
    {

        private static List<StatisticData> _statistics;

        // TODO удалить
        #region
        public static event System.Action TestEvent;

        public static void Trigger()
        {
            TestEvent?.Invoke();
        }
        #endregion
        //


        /// <summary>
        /// Устанавливает новое значение статистик
        /// </summary>
        /// <param name="stats">Список статистик</param>
        public static void SetStatistics(List<StatisticData> stats)
        {
            _statistics = stats;
        }


        /// <summary>
        /// Устанавливет значения статистик по умолчанию
        /// </summary>
        public static void SetStatistics()
        {
            _statistics = StatisticFactory.GetStatistics();
        }


        /// <summary>
        /// Получение определённой статистики
        /// </summary>
        /// <typeparam name="T">Тип статистики</typeparam>
        /// <returns></returns>
        public static T GetStatistic<T>()
            where T : StatisticData
        {
            if (_statistics == null)
                return null;


            var tmp = _statistics.OfType<T>().ToArray();
            if (tmp.Length == 0)
                return null;

            return tmp[0];
        }

    }
}