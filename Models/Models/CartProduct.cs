using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int? PlantId { get; set; }
        public virtual Plant Plant { get; set; }
        public int? ToolId { get; set; }
        public virtual Tool Tool { get; set; }
        public int? CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public int Quantity { get; set; }
    }
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(b => b.Plant)
                   .WithMany(ub => ub.Carts)
                   .HasForeignKey(b => b.PlantId);

            builder.HasOne(b => b.Tool)
                  .WithMany(ub => ub.Carts)
                  .HasForeignKey(b => b.ToolId);

            builder.HasOne(x => x.Cart)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CartId);
        }
    }
}
