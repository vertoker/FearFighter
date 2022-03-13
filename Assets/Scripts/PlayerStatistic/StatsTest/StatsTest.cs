using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PlayerStatisticSystem;

public class StatsTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void DefaultStats ()
    {
        PlayerStatistic.SetStatistics();
        Assert.AreEqual(0, PlayerStatistic.GetStatistic<GamesCount>().countOfGames);
    }


    [Test]
    public void SetStats()
    {
        List<StatisticData> stats = new List<StatisticData>() { new GamesCount() };
        PlayerStatistic.SetStatistics(stats);
        Assert.AreEqual(0, PlayerStatistic.GetStatistic<GamesCount>().countOfGames);
    }

    [Test]
    public void ChangeStatsValue()
    {
        PlayerStatistic.SetStatistics();
        PlayerStatistic.Trigger();
        Assert.AreEqual(1, PlayerStatistic.GetStatistic<GamesCount>().countOfGames);
    }
}
