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
        //public DbSet<Report> Reports { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<UserRole>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");

            modelBuilder.Entity<Scooter>().ToTable("scooter");
            modelBuilder.Entity<Scooter>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Scooter>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Scooter>().HasIndex(x => x.Name).IsUnique();

            //modelBuilder.Entity<ScooterDetail>().ToTable("scooter_details");
            //modelBuilder.Entity<ScooterDetail>().HasOne(x => x.Scooter).WithOne(x => x.Detail).HasPrincipalKey<ScooterDetail>(x => x.Id);

            modelBuilder.Entity<Rental>().ToTable("rental");
            modelBuilder.Entity<Rental>().HasOne(x => x.Scooter).WithMany(x => x.Rentals).HasForeignKey(x => x.ScooterId).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Report>().HasOne(x => x.Period).WithOne(x => x.Report).HasForeignKey<Report>(x => x.PeriodId);
            //modelBuilder.Entity<Revenue>().HasOne(x => x.Rental).WithOne(x => x.Report).HasForeignKey<Report>(x => x.PeriodId);


            //modelBuilder.Entity<Scooter>()
            //    .HasKey(s => s.Id);

            //modelBuilder.Entity<Rental>()
            //    .HasKey(r => r.Id);


            //modelBuilder.Entity<User>()
            //    .HasKey(u => u.Id);

            //modelBuilder.Entity<Report>()
            //    .HasKey(r => r.Id);



            //modelBuilder.Entity<Rental>()
            //    .HasOne(r => r.User)
            //    .WithMany(u => u.Rentals)
            //    .HasForeignKey(r => r.UserId);
            //modelBuilder.Entity<Book>().HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Rental>().HasOne(x => x.Scooter).WithMany(x => x.Rentals).HasForeignKey(x => x.ScooterId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Rental>()
            //    .HasOne(r => r.Scooter)
            //    .WithMany(s => s.Rentals)
            //    .HasForeignKey(r => r.ScooterId)
            //    .OnDelete(DeleteBehavior.Restrict); //У каждой аренды есть задействованый самокат,
                                                    //и только один притом у каждого самоката может быть много аренд а может и не быть - связь 1:n


        }
    }
}
