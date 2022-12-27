using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Villas> Villas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<VillaAmenities> VillaAmenities { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }

        //public DbSet<FileCSV> Units { get; set; }
       
    }
}
