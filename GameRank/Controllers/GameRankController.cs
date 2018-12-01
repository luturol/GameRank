using GameRank.Context;
using GameRank.Models;
using GameRank.Repository;
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
        private IGameResultRepository repository;

        public GameRankController(IGameResultRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var result = repository.GetTopHundred();
                return Ok(result);
            }
            catch (Exception ex)
            { 
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(GameResultDTO gameResult)
        {
            try
            {           
                return Ok(repository.Add(gameResult));
            }
            catch (Exception ex)
            {                
                return InternalServerError(ex);
            }
        }
    }
}
