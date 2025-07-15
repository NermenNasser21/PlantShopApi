using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PlantUsage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }

    }
    public class PlantUsageConfiguration : IEntityTypeConfiguration<PlantUsage>
    {
        public void Configure(EntityTypeBuilder<PlantUsage> builder)
        {
            builder.HasMany(b => b.Plants)
             .WithOne(ub => ub.Usage);

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
