using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameRank.Models
{
    public class GameResult
    {
        [Key, Column(Order=0)]
        public long GameID { get; set; }
        [Key, Column(Order = 1)]
        public long PlayerID { get; set; }
        public long Win { get; set; } 
        public DateTime Timestamp { get; set; }
    }
}