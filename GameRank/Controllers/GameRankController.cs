using GameRank.Context;
using GameRank.Models;
using GameRank.Repository;
using GameRank.Service;
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
        private GameResultService service;

        public GameRankController(GameResultService service)
        {
            this.service = service;
        }
        
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var result = service.GetTopHundred();
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
                return Ok(service.Add(gameResult));
            }
            catch (Exception ex)
            {                
                return InternalServerError(ex);
            }
        }
    }
}
