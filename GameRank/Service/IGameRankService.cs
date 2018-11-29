using GameRank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRank.Service
{
    public interface IGameRankService
    {
        bool SaveGameRank(GameResult gameResult);
        List<GameResult> GetAll();
    }
}
