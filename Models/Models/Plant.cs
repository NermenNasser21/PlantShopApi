using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Plant
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category {  get; set; }
        public decimal? Rate {  get; set; }
        public string? LightAndHeat { get; set; }
        public string? Irrigation { get; set; }
        public string? Reproduction { get; set; }
        public string? Fertilizers { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<CartProduct> Carts { get; set; }
        public virtual ICollection<OrderedProduct> Orders {  get; set; }
        public virtual ICollection<Review> Reviews {  get; set; }



    }
    public class ProductConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Quantity)
                .IsRequired();
            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(200); 
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(b => b.Price)
               .IsRequired();

            builder.HasOne(b => b.Category)
                .WithMany(b => b.Products)
                .HasForeignKey(b => b.CategoryId);

            
        }
    }

}
