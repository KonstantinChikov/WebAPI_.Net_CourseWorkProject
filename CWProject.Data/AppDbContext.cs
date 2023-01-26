using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CWProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Villas> Villas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<VillaAmenities> VillaAmenities { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Navigation(u => u.Role)
                .AutoInclude();

            base.OnModelCreating(modelBuilder);
        }

    }
}
