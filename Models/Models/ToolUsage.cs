using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ToolUsage
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Tool> Tools { get; set; }

    }
    public class ToolUsageConfiguration : IEntityTypeConfiguration<ToolUsage>
    {
        public void Configure(EntityTypeBuilder<ToolUsage> builder)
        {
            builder.HasMany(b => b.Tools)
             .WithOne(ub => ub.ToolUsage);

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}
