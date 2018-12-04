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

        public bool Add(GameResultDTO gameResult)
        {

            if (!ValidaDados(gameResult))
            {
                return false;
            }
            else
            {
                GameResult newGame = new GameResult()
                {
                    GameID = gameResult.GameID,
                    PlayerID = gameResult.PlayerID,
                    Timestamp = gameResult.Timestamp,
                    Win = gameResult.Win
                };

                return Save(newGame);
            }
        }

        private bool Save(GameResult newGameResult)
        {
            if (gameResults.Any(e => e.GameID == newGameResult.GameID && e.PlayerID == newGameResult.PlayerID))
            {
                GameResult game = gameResults[gameResults.IndexOf(newGameResult)];
                game.Win += newGameResult.Win;
                return true;
            }
            else
            {
                gameResults.Add(newGameResult);
                return true;
            }
        }

        private bool ValidaDados(GameResultDTO gameResultDTO)
        {
            if (gameResultDTO != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
    }
}
