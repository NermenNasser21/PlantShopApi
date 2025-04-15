using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public int Quantity { get; set; }
    }
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(x=>x.Carts)
                .HasForeignKey(x=>x.ProductId);

            builder.HasOne(x => x.Cart)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CartId);
        }
    }
}
