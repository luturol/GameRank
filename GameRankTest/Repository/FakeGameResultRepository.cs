using GameRank.Models;
using GameRank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRankTest.Repository
{
    public class FakeGameResultRepository : IGameResultRepository
    {
        public List<GameResult> gameResults = new List<GameResult>();

        public bool Add(GameResultDTO gameResultDTO)
        {            
            gameResults.Add(Create(gameResultDTO));
            return true;

        }

        public IEnumerable<GameResultDTO> GetTopHundred()
        {
            return (from games in gameResults
                    orderby games.Win descending
                    select new GameResultDTO
                    {
                        GameID = games.GameID,
                        PlayerID = games.PlayerID,
                        Win = games.Win,
                        Timestamp = games.Timestamp
                    }).ToList().Take(100);
        }

        public bool Update(GameResultDTO gameResultDTO)
        {
            GameResult newGame = Create(gameResultDTO);
            GameResult game = gameResults[gameResults.FindIndex(e => e.GameID == newGame.GameID && e.PlayerID == newGame.PlayerID)];
            game.Win += newGame.Win;
            return true;
        }

        public bool ExistGameResultWithSameGameIdAndPlayerId(GameResultDTO gameResultDTO)
        {
            return gameResults.Any(e => e.GameID == gameResultDTO.GameID && e.PlayerID == gameResultDTO.PlayerID);
        }

        private GameResult Create(GameResultDTO gameResultDTO)
        {
           return new GameResult()
            {
                GameID = gameResultDTO.GameID,
                PlayerID = gameResultDTO.PlayerID,
                Timestamp = gameResultDTO.Timestamp,
                Win = gameResultDTO.Win
            };
        }
    }
}
