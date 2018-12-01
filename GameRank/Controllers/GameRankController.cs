using GameRank.Context;
using GameRank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameRank.Controllers
{
    public class GameRankController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();
        
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var result = db.GameResults.Select(e => e);
                return Ok(result);
            }
            catch (Exception)
            { 
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post(GameResult gameResult)
        {
            try
            {
                int result = 0;
                if(db.GameResults.Any(e => e.GameID == gameResult.GameID && e.PlayerID == gameResult.PlayerID))
                {
                    GameResult game = db.GameResults.Single(e => e.GameID == gameResult.GameID && e.PlayerID == gameResult.PlayerID);
                    game.Win += gameResult.Win;
                    game.Timestamp = gameResult.Timestamp;
                    
                    result = db.SaveChanges();
                }
                else
                {
                    db.GameResults.Add(gameResult);
                    result = db.SaveChanges();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }
    }
}
