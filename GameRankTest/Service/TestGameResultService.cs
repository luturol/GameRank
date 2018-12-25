using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameRank.Models;
using GameRank.Service;
using GameRankTest.Repository;

namespace GameRank.Service
{
    [TestClass]
    public class TestGameResultService
    {
        [TestMethod]
        public void ShouldBeAbleToAddNewGameResult()
        {
            GameResultService service = new GameResultService(new FakeGameResultRepository());
            GameResultDTO dto = new GameResultDTO()
            {
                GameID = 1,
                PlayerID = 1,
                Timestamp = DateTime.Now,
                Win = 2
            };

            Assert.IsTrue(service.Add(dto));
        }

        [TestMethod]
        public void ShouldBeAbleToUpdateGameResult()
        {
            GameResultService service = new GameResultService(new FakeGameResultRepository());
            GameResultDTO dto = new GameResultDTO()
            {
                GameID = 1,
                PlayerID = 1,
                Timestamp = DateTime.Now,
                Win = 2
            };
            service.Add(dto);
            Assert.IsTrue(service.Add(dto));
        }
    }
}
