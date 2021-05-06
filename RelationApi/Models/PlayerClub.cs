using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationApi.Models
{
    public class PlayerClub
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }

        public Player Player { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}
