using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationApi.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerClub>()
                .HasOne(p => p.Player)
                .WithMany(p => p.PlayerClubs)
                .HasForeignKey(p => p.PlayerId);

            modelBuilder.Entity<PlayerClub>()
               .HasOne(p => p.Club)
               .WithMany(p => p.PlayerClubs)
               .HasForeignKey(p => p.ClubId);


        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<PlayerClub> PlayerClubs { get; set; }
    }
}
