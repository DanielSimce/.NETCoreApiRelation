﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerClub> PlayerClubs { get; set; }
    }
}
