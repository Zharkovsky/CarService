using CarService.Models;
using System.Data.Entity;

namespace CarService
{
    public class Context : DbContext
    {
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OrderQualification> OrderQualifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MechanicQualification> MechanicQualifications { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public Context() : base(nameOrConnectionString: "Default") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Order>().HasRequired(_ => _.Car).WithMany(_ => _.Orders).HasForeignKey(_ => _.Grz);
            modelBuilder.Entity<Order>().HasRequired(_ => _.Mechanic).WithMany(_ => _.Orders).HasForeignKey(_ => _.MechanicId);
            modelBuilder.Entity<Order>().HasRequired(_ => _.Workshop).WithMany(_ => _.Orders).HasForeignKey(_ => _.WorkshopId);
            modelBuilder.Entity<Order>().HasRequired(_ => _.OrderQualification).WithMany(_ => _.Orders).HasForeignKey(_ => _.OrderQualificationName);

            modelBuilder.Entity<Mechanic>().HasRequired(_ => _.MechanicQualification).WithMany(_ => _.Mechanics).HasForeignKey(_ => _.MechanicQualificationName);
            modelBuilder.Entity<Mechanic>().HasRequired(_ => _.Workshop).WithMany(_ => _.Mechanics).HasForeignKey(_ => _.WorkshopId);

            modelBuilder.Entity<Car>().HasRequired(_ => _.Owner).WithMany(_ => _.Cars).HasForeignKey(_ => _.Driverlicense);
            modelBuilder.Entity<Car>().HasRequired(_ => _.Brand).WithMany(_ => _.Cars).HasForeignKey(_ => _.BrandName);

            base.OnModelCreating(modelBuilder);
        }
    }
}