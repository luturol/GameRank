using GameRank.Models;
using GameRank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameRank.Service
{
    public class GameRankService : IGameRankService
    {
        private IGameRankRepository repository;

        public GameRankService(IGameRankRepository repository)
        {
            this.repository = repository;
        }

        public bool SaveGameRank(GameResult gameResult)
        {
            return repository.Save(gameResult);
        }
        
        public List<GameResult> GetAll()
        {
            return repository.GetAll();
        }
    }
}