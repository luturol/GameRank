﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameRank.Models
{
    public class GameResultDTO
    {
        public long GameID { get; set; }
        public long PlayerID { get; set; }
        public long Win { get; set; }
        public DateTime Timestamp { get; set; }
    }
}