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
    public class OrderedProduct
    {
        public int Id { get; set; }
        public int? PlantId { get; set; }
        public virtual Plant Plant {  get; set; }
        public int? ToolId { get; set; }
        public virtual Tool Tool { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity{ get; set; }

    }
    public class OrderedProductConfiguration : IEntityTypeConfiguration<OrderedProduct>
    {
        public void Configure(EntityTypeBuilder<OrderedProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(b => b.Plant)
                   .WithMany(ub => ub.Orders)
                   .HasForeignKey(b=>b.PlantId);

            builder.HasOne(b => b.Tool)
                  .WithMany(ub => ub.Orders)
                  .HasForeignKey(b => b.ToolId);

            builder.HasOne(b => b.Order)
                  .WithMany(ub => ub.Products)
                  .HasForeignKey(b => b.OrderId);

        }
    }
 }
