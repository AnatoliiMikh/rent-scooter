using RentScooter.Context.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentScooter.Context
{
    public class MainDbContext : IdentityDbContext<User, UserRole, Guid>
    { 
        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scooter>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Rental>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Report>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Scooter)
                .WithMany(s => s.Rentals)
                .HasForeignKey(r => r.ScooterId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rentals)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Period)
                .WithOne(p => p.Report)
                .HasForeignKey<Report>(r => r.PeriodId);
        }
    }
}
