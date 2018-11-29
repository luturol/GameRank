using GameRank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRank.Repository
{
    public interface IGameRankRespository
    {
        bool Save(GameResult gameResult);
        List<GameResult> GetAll();
    }
}
