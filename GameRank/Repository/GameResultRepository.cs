using GameRank.Context;
using GameRank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GameRank.Repository
{
    public class GameResultRepository : IGameResultRepository
    {
        private DatabaseContext db = new DatabaseContext();      

        public IEnumerable<GameResultDTO> GetTopHundred()
        {
            return (from games in db.GameResults
                    orderby games.Win descending
                    select new GameResultDTO
                    {
                        GameID = games.GameID,
                        PlayerID = games.PlayerID,
                        Win = games.Win,
                        Timestamp = games.Timestamp
                    }).ToList().Take(100);
        }

        public bool Add(GameResultDTO gameResultDTO)
        {
            if(db.GameResults.Any(e => e.GameID == gameResultDTO.GameID && e.PlayerID == gameResultDTO.PlayerID))
            {
                return UpdateGameResult(gameResultDTO);
            }
            else
            {
                return AddNewGameResult(gameResultDTO);
            }
        }

        private bool UpdateGameResult(GameResultDTO gameResultDTO)
        {
            GameResult game = db.GameResults.Single(e => e.GameID == gameResultDTO.GameID && e.PlayerID == gameResultDTO.PlayerID);
            game.Win += gameResultDTO.Win;
            game.Timestamp = gameResultDTO.Timestamp;
            return db.SaveChanges() > 0;
        }

        private bool AddNewGameResult(GameResultDTO gameResultDTO)
        {
            db.GameResults.Add(new GameResult()
            {
                GameID = gameResultDTO.GameID,
                PlayerID = gameResultDTO.PlayerID,
                Win = gameResultDTO.Win,
                Timestamp = gameResultDTO.Timestamp
            });
            return db.SaveChanges() > 0;
        }
    }
}