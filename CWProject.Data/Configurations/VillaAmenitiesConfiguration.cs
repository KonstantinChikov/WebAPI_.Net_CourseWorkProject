using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Data.Configurations
{
    public class VillaAmenitiesConfiguration : IEntityTypeConfiguration<VillaAmenities>
    {
        public void Configure(EntityTypeBuilder<VillaAmenities> builder)
        {
            builder.HasKey(tcm => new { tcm.VillasId, tcm.AmenitiesId });

            builder.HasOne(tcm => tcm.Amenities)
                .WithMany(t => t.VillaAmenities)
                .HasForeignKey(tcm => tcm.AmenitiesId);

            builder.HasOne(tcm => tcm.Villas)
                .WithMany(tc => tc.VillaAmenities)
                .HasForeignKey(tcm => tcm.VillasId);
        }
    }
}
