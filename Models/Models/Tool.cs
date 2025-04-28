using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal? Rate { get; set; }
        public string? Image { get; set; }
        public int ToolUsageId { get; set; }
        public virtual ToolUsage ToolUsage { get; set; }

        public virtual ICollection<CartProduct> Carts { get; set; }
        public virtual ICollection<OrderedProduct> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }

    public class ToolConfiguration : IEntityTypeConfiguration<Tool>
    {
        public void Configure(EntityTypeBuilder<Tool> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Quantity)
                .IsRequired();
            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(70);
            builder.Property(b => b.Price)
               .IsRequired();

            builder.HasOne(b => b.ToolUsage)
                .WithMany(b => b.Tools)
                .HasForeignKey(b => b.ToolUsageId);


        }
    }

}
