using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PlantEnvironment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Plant> Plants {  get; set; }
    }

    public class PlantEnvironmentConfiguration : IEntityTypeConfiguration<PlantEnvironment>
    {
        public void Configure(EntityTypeBuilder<PlantEnvironment> builder)
        {
            builder.HasMany(b => b.Plants)
             .WithOne(ub => ub.Environment);

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
