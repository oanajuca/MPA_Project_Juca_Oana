using Microsoft.EntityFrameworkCore;
using MPA_Project_Juca_Oana.Models;

namespace MPA_Project_Juca_Oana.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Stadiums> Stadiums { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Players> City { get; set; }
        public DbSet<Players> StadiumByCity { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().ToTable("Customers");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<Stadiums>().ToTable("Stadiums");
            modelBuilder.Entity<Teams>().ToTable("Teams");
            modelBuilder.Entity<Trainers>().ToTable("Trainers");
            modelBuilder.Entity<Players>().ToTable("Players");
            modelBuilder.Entity<City>().ToTable("City"); 
            modelBuilder.Entity<StadiumByCity>().ToTable("StadiumByCity");
            modelBuilder.Entity<StadiumByCity>().HasKey(c => new { c.StadiumID, c.CityID });



        }


        public DbSet<MPA_Project_Juca_Oana.Models.City> City_1 { get; set; }

    }
}
