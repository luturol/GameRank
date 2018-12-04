using System;
using GameRank.Models;
using GameRankTest.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameRank.Repository
{
    [TestClass]
    public class TestGameResultRepository
    {
        [TestMethod]
        public void TestSuccessfullyAddNewGameResult()
        {
            FakeGameResultRepository fakeGameResultRepository = new FakeGameResultRepository();
            GameResultDTO FakeGame = new GameResultDTO()
            {
                GameID = 1,
                PlayerID = 1,
                Timestamp = DateTime.Now,
                Win = 2
            };
            Assert.IsTrue(fakeGameResultRepository.Add(FakeGame));
        }        
    }
}
