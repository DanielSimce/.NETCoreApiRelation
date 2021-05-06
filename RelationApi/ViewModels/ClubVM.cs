using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationApi.ViewModels
{
    public class ClubVM
    {
        public string ClubName { get; set; }
    }

    public class ClubWithPlayerVM
    {
        public string Name { get; set; }
        public List<int> PlayersIds { get; set; }
    }

    public class ClubPlayerName
    {
        public string ClubName { get; set; }
        public List<string> PlayerNames { get; set; }
    }
}
