using GameRank.Models;
using GameRank.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace GameRank.Controllers
{
    public class GameRankController : ApiController
    {
        private IGameRankService service;

        public GameRankController(IGameRankService service)
        {
            this.service = service;
        }

        [HttpPost]
        // POST api/GameRank
        public void Post([FromBody]GameResult gameResult)
        {
            service.SaveGameRank(gameResult);
        }

        public List<GameResult> GetAll()
        {
            return service.GetAll();
        }
    }
}
