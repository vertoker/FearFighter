using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStatistic
{

    [System.Serializable]
    public class GamesCount : StatisticData
    {
        public int countOfGames { get; private set; }  // Кол-во сыгранных игр


        public GamesCount()
        {
            countOfGames = 0;

            Registrate();

        }

        

        protected override void Registrate()
        {
            // TODO регистрация на события, изменяющие данную статистику
            PlayerStatistic.TestEvent += () => { countOfGames++; OnStatsChanged(); };
        }
    }
}