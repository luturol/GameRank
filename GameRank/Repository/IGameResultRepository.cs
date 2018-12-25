using GameRank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRank.Repository
{
    public interface IGameResultRepository
    {
        IEnumerable<GameResultDTO> GetTopHundred();
        bool Add(GameResultDTO gameResultDTO);
        bool Update(GameResultDTO gameResultDTO);
        bool ExistGameResultWithSameGameIdAndPlayerId(GameResultDTO gameResultDTO);
    }
}
