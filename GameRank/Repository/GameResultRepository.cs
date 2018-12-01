using GameRank.Context;
using GameRank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameRank.Repository
{
    public class GameResultRepository : IGameResultRepository
    {
        private DatabaseContext db = new DatabaseContext();

        public IEnumerable<GameResult> GetTopHundred()
        {
            return (from games in db.GameResults
                    orderby games.Win descending
                    select new GameResult
                    {
                        GameID = games.GameID,
                        PlayerID = games.PlayerID,
                        Win = games.Win,
                        Timestamp = games.Timestamp
                    }).ToList().Take(100);
        }

        public bool Add(GameResult gameResult)
        {
            if(db.GameResults.Any(e => e.GameID == gameResult.GameID && e.PlayerID == gameResult.PlayerID))
            {
                GameResult game = db.GameResults.Single(e => e.GameID == gameResult.GameID && e.PlayerID == gameResult.PlayerID);
                game.Win += gameResult.Win;
                game.Timestamp = gameResult.Timestamp;
                return db.SaveChanges() > 0;
            }
            else
            {
                db.GameResults.Add(gameResult);
                return db.SaveChanges() > 0;
            }
        }
    }
}