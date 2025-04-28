using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderedProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Plant Product {  get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity{ get; set; }

    }
    public class OrderedProductConfiguration : IEntityTypeConfiguration<OrderedProduct>
    {
        public void Configure(EntityTypeBuilder<OrderedProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(b => b.Product)
                   .WithMany(ub => ub.Orders)
                   .HasForeignKey(b=>b.ProductId);

            builder.HasOne(b => b.Order)
                  .WithMany(ub => ub.Products)
                  .HasForeignKey(b => b.OrderId);

        }
    }
 }
