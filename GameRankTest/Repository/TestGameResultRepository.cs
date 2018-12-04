using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void TestUnsuccessfullyAddNewGameResult()
        {
            FakeGameResultRepository fakeGameResultRepository = new FakeGameResultRepository();           
            Assert.IsFalse(fakeGameResultRepository.Add(null));
        }

        [TestMethod]
        public void TestSuccessfullyGetTopHundred()
        {
            FakeGameResultRepository fakeGameResultRepository = new FakeGameResultRepository();
            List<GameResultDTO> allGames = new List<GameResultDTO>();
            Random random = new Random();
            for (int i = 0; i < 140; i++)
            {
                GameResultDTO FakeGame = new GameResultDTO()
                {
                    GameID = random.Next(1, 140),
                    PlayerID = random.Next(1, 140),
                    Timestamp = DateTime.Now,
                    Win = random.Next(1, 200)
                };
                allGames.Add(FakeGame);
                fakeGameResultRepository.Add(FakeGame);
            }

            IEnumerable<GameResultDTO> top100 = (from games in allGames
                                          orderby games.Win descending
                                          select new GameResultDTO
                                          {
                                              GameID = games.GameID,
                                              PlayerID = games.PlayerID,
                                              Win = games.Win,
                                              Timestamp = games.Timestamp
                                          }).ToList().Take(100);
            
            int total = top100.ToList().Count;
            int totalFake = fakeGameResultRepository.GetTopHundred().ToList().Count;
            Assert.AreEqual(total, 100);            
            Assert.AreEqual(total, totalFake);
        }
    }
}
