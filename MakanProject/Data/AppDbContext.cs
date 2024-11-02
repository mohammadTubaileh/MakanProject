using MakanProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MakanProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace MakanProject.Data
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions options) : base(options) { }
		public DbSet<Apartment> Apartments { get; set; }
		public DbSet<Villa> Villas { get; set; }
		public DbSet<Location> Locations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Villa) // The Booking has one Villa
                .WithMany(v => v.Bookings) // The Villa has many Bookings
                .HasForeignKey(b => b.VillaId); // VillaId is the foreign key
        }



    }
}
