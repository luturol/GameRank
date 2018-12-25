using GameRank.Models;
using GameRank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameRank.Service
{
    public class GameResultService
    {
        private IGameResultRepository repository;        

        public GameResultService(IGameResultRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<GameResultDTO> GetTopHundred()
        {
            return repository.GetTopHundred();
        }

        public bool Add(GameResultDTO gameResultDTO)
        {
            if (repository.ExistGameResultWithSameGameIdAndPlayerId(gameResultDTO))
            {
                return repository.Update(gameResultDTO);
            }
            else
            {
                return repository.Add(gameResultDTO);
            }
        }        
    }
}