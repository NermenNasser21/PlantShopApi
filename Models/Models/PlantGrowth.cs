using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PlantGrowth
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }
    }
    public class PlantGrowthConfiguration : IEntityTypeConfiguration<PlantGrowth>
    {
        public void Configure(EntityTypeBuilder<PlantGrowth> builder)
        {
            builder.HasMany(b => b.Plants)
             .WithOne(ub => ub.Growth);

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
