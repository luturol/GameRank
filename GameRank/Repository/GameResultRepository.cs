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
            db.GameResults.Add(new GameResult()
            {
                GameID = gameResultDTO.GameID,
                PlayerID = gameResultDTO.PlayerID,
                Win = gameResultDTO.Win,
                Timestamp = gameResultDTO.Timestamp
            });
            return db.SaveChanges() > 0;
        }

        public bool Update(GameResultDTO gameResultDTO)
        {
            GameResult game = db.GameResults.Single(e => e.GameID == gameResultDTO.GameID && e.PlayerID == gameResultDTO.PlayerID);
            game.Win += gameResultDTO.Win;
            game.Timestamp = gameResultDTO.Timestamp;
            return db.SaveChanges() > 0;
        }

        public bool ExistGameResultWithSameGameIdAndPlayerId(GameResultDTO gameResult)
        {
            return db.GameResults.Any(e => e.GameID == gameResult.GameID && e.PlayerID == gameResult.PlayerID);
        }
    }
}