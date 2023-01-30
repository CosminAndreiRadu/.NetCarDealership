 using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectDaw.Models.Entities;

namespace ProiectDaw.Data
{
    public class DBcon : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, 
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DBcon(DbContextOptions options) :base(options) { }

        public DbSet<SessionToken> SessionTokens { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<QATester> QATesters { get; set; }
        public DbSet<VehicleTester> vehicleTesters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Manufacturer>()
                .HasOne(m => m.Location)
                .WithOne(l => l.Manufacturer);

            //OTM Manufacturer-Vehicles

            modelBuilder.Entity<Manufacturer>()
                .HasMany(m => m.Vehicles)
                .WithOne(v => v.Manufacturer);

            //MTM QATester - VehicleTester - Vehicle

            modelBuilder.Entity<VehicleTester>().HasKey(vt => new { vt.VehicleId, vt.QATesterId });

            modelBuilder.Entity<VehicleTester>()
                .HasOne(vt => vt.Vehicle)
                .WithMany(v => v.VehicleTesters)
                .HasForeignKey(vt => vt.VehicleId);

            modelBuilder.Entity<VehicleTester>()
                .HasOne(vt => vt.QATester)
                .WithMany(q => q.VehicleTesters)
                .HasForeignKey(vt => vt.QATesterId);


            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new {ur.UserId, ur.RoleId});

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

            });

            
        }
    }
}
