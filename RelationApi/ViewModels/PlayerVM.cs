using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationApi.ViewModels
{
    public class PlayerVM
    {
        public string Name { get; set; }
    }

    public class PlayerWithClubVM
    {
        public string Name { get; set; }
        public List<int> ClubsIds { get; set; }
    }

    public class PlayerClubNamesVm
    {
        public string PlayerName { get; set; }
        public List<string> ClubName { get; set; }
    }
}
