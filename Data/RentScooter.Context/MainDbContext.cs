using RentScooter.Context.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentScooter.Context
{
    public class MainDbContext : IdentityDbContext<User, UserRole, Guid>
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandDetail> BrandDetails { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Scooter> Scooters { get; set; }

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

            modelBuilder.Entity<Brand>().ToTable("brands");
            modelBuilder.Entity<Brand>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Brand>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Brand>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<BrandDetail>().ToTable("brand_details");
            modelBuilder.Entity<BrandDetail>().HasOne(x => x.Brand).WithOne(x => x.Detail).HasPrincipalKey<BrandDetail>(x => x.Id);

            modelBuilder.Entity<Scooter>().ToTable("scooters");
            modelBuilder.Entity<Scooter>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Scooter>().Property(x => x.Title).HasMaxLength(250);
            modelBuilder.Entity<Scooter>().HasOne(x => x.Brand).WithMany(x => x.Scooters).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rent>().ToTable("rents");
            modelBuilder.Entity<Rent>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Rent>().Property(x => x.Title).HasMaxLength(100);
            modelBuilder.Entity<Rent>().HasMany(x => x.Scooters).WithMany(x => x.Rents).UsingEntity(t => t.ToTable("scooters_categories"));
        }
    }
}
