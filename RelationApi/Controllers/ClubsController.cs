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
    public class ClubsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public ClubsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<ClubVM> Post(ClubVM clubVM)
        {
            var club = new Club()
            {
                Name = clubVM.ClubName
            };

            _context.Clubs.Add(club);
            _context.SaveChanges();

            return Ok(club);
        }

        [HttpGet]
        public ActionResult<List<Club>> All()
        {
            return Ok(_context.Clubs.ToList().Select(x => new { x.Id, x.Name }));
        }

        [HttpPost("Clubs-with-players")]
        public ActionResult<ClubWithPlayerVM> Post(ClubWithPlayerVM clubWithPlayerVM)
        {
            var club = new Club()
            {
                Name = clubWithPlayerVM.Name
            };

            _context.Clubs.Add(club);
            _context.SaveChanges();

            foreach (var id in clubWithPlayerVM.PlayersIds)
            {
                var playerClub = new PlayerClub()
                {
                    PlayerId = id,
                    ClubId = club.Id
                };

                _context.PlayerClubs.Add(playerClub);
                _context.SaveChanges();
            }

            return Ok(club);
        }

        [HttpGet("Club-with-players/{id}")]
        public ActionResult<ClubPlayerName> ClubPlayerName(int id)
        {
            var clubPlayerName = _context.Clubs.Where(x => x.Id == id).Select(club => new ClubPlayerName()
            {
                ClubName = club.Name,
                PlayerNames = club.PlayerClubs.Select(x => x.Player.Name).ToList()

            }).FirstOrDefault();

            return Ok(clubPlayerName);
        }
    }
}
