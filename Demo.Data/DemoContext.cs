using Demo.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.Data
{
    public class DemoContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Demo");
        }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Player> Players { get; set; }
    }
}
