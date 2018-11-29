﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameRank.Models;
namespace GameRank.Repository
{
    public class GameRankRepository : IGameRankRepository
    {
        private List<GameResult> gameResults;

        public GameRankRepository()
        {
            gameResults = new List<GameResult>();
        }

        public bool Save(GameResult gameResult)
        {
            if(gameResults.Any(game => game.PlayerID == gameResult.PlayerID && game.GameID == gameResult.GameID))
            {
                GameResult game = gameResults.Single(games => games.PlayerID == gameResult.PlayerID && games.GameID == gameResult.GameID);
                game.Win += gameResult.Win;
                return true;
            }
            else
            {
                gameResults.Add(gameResult);
                return true;
            }
        }

        public List<GameResult> GetAll()
        {
            return gameResults;
        }
    }
}