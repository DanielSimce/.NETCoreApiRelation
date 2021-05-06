using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelationApi.Models;
using RelationApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public PlayersController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<PlayerVM> Post(PlayerVM playerVM)
        {
            var player = new Player()
            {
                Name = playerVM.Name
            };

            _context.Players.Add(player);
            _context.SaveChanges();

            return Ok(player);
        }

        [HttpGet]
        public ActionResult<Player> All()
        {
            return Ok(_context.Players.ToList().Select(x => new { x.Id, x.Name }));
        }

        [HttpPost("Player-with-clubs")]
        public ActionResult<PlayerWithClubVM> Post(PlayerWithClubVM playerWithClub)
        {
            var player = new Player()
            {
                Name = playerWithClub.Name
            };

            _context.Players.Add(player);
            _context.SaveChanges();

            foreach (var id in playerWithClub.ClubsIds)
            {
                var playerClub = new PlayerClub()
                {
                    PlayerId = player.Id,
                    ClubId = id
                };

                _context.PlayerClubs.Add(playerClub);
                _context.SaveChanges();
            }

            return Ok(player);
        }

        [HttpGet("Player-with-Clubs/{id}")]
        public ActionResult<PlayerClubNamesVm> PlayerWithClubs(int id)
        {
            var playerClubnamesVM = _context.Players.Where(x => x.Id == id).Select(player => new PlayerClubNamesVm()
            {

                PlayerName = player.Name,
                ClubName = player.PlayerClubs.Select(x => x.Club.Name).ToList()

            }).FirstOrDefault();

           
            return Ok(playerClubnamesVM);
        }
    }
}
