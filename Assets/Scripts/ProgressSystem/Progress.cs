using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Entities;
using InventorySystem;

namespace ProgressSystem
{
    public class Progress
    {
        public InventoryController playerInventory { get; private set; }

        public Stats playerStats { get; private set; }

        public Stats currentStats { get; private set; }  // Текущие статы


        // Реализация синглтона
        #region 
        private static Progress instance;
        private Progress()
        {
            playerInventory = new InventoryController();
            playerStats = new Stats();
            currentStats = playerStats;
        }

        public static Progress GetInstance()
        {
            if (instance == null)
                instance = new Progress();

            return instance;
        }
        #endregion


        /// <summary>
        /// Расчитывает текущие статы персонажа
        /// </summary>
        public void CalculateStats()
        {
            currentStats = playerStats;

            foreach (var item in playerInventory.GetItems())
            {
                IHaveEffect effectItem = item as IHaveEffect;
                if (effectItem != null)
                    currentStats += effectItem.GetEffect();
            }
        }


        /// <summary>
        /// Установка нового значения стат персонажа
        /// </summary>
        /// <param name="stats"></param>
        public void SetStats(Stats stats)
        {
            currentStats = stats;
        }
    }
}