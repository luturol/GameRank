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
        IEnumerable<GameResult> GetTopHundred();
        bool Add(GameResult gameResult);
    }
}
