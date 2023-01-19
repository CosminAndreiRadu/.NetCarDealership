using Microsoft.EntityFrameworkCore;
using ProiectDaw.Entities;

namespace ProiectDaw.Data
{
    public class DBcon : DbContext
    {
        public DBcon(DbContextOptions<DBcon> options) :base(options) { }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<QATester> QATesters { get; set; }
        public DbSet<VehicleTester> vehicleTesters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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


            base.OnModelCreating(modelBuilder);
        }
    }
}
