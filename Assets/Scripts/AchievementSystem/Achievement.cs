﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AchievementsSystem
{
	[System.Serializable]
	public struct Achievement
	{
		/// <summary>
		/// Значение тукущего прогресса достижения
		/// </summary>
		public float CurrentProgress
		{
			get
			{
				return progressFunction();
			}
		}


		/// <summary>
		/// Id достижения
		/// </summary>
		/// <value></value>
		public int id { get; private set; }                               // Id достижения


		/// <summary>
		/// Событие получение события
		/// </summary>
		public static event Action<Achievement> AchievementGotEvent;

		public bool IsGot { get { return CurrentProgress == 1; } }        // Полученно ли достижение?

		private Func<float> progressFunction;                             // Функция, возвращающая текущий прогресс по достижению

		private int awardAmount;                                          // Величина награды
		private bool awardGot;                                            // Получена ли награда


		/// <summary>
		/// Создаёт экземпляр структуры Achievement
		/// </summary>
		/// <param name="progress">Функция, определяющая прогресс по достижению</param>
		/// <param name="id">Id достижения</param>
		/// <param name="award">Величина награды</param>
		public Achievement(Func<float> progress, int id, int award)
		{
			progressFunction = progress;
			this.id = id;
			awardAmount = award;
			awardGot = false;
			PlayerStatisticSystem.StatisticData.StatisticChangedEvent += CheckAchievement;
		}


		/// <summary>
		/// Получение награды
		/// </summary>
		public void GetAward()
		{
			if (!awardGot)
				Debug.Log("Получена награда");
			else
				Debug.Log("Награда была получена ранее");
		}


		private void CheckAchievement()
        {
			if (progressFunction() == 1)
            {
				AchievementGotEvent?.Invoke(this);
				PlayerStatisticSystem.StatisticData.StatisticChangedEvent -= CheckAchievement;
			}
        }
	}
}