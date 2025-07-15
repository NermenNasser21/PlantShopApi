using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Enums;


namespace Models
{
    public class Order
    {
        public int Id { get; set; }
        public PaymentWays PaymentWay { get; set; }
        public orderStatus status {  get; set; }
        //public decimal DeliveryPrice { get; set; }
        public DelivaryDetails? DelivaryDetails { get; set; }
        public string? Picture { get; set; }
        public string City { get; set; }
        public string? Note { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime Time {  get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderedProduct> Products { get; set; }


    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(b => b.User)
                   .WithMany(ub => ub.Orders)
                   .HasForeignKey(b => b.UserId);

            builder.Property(i => i.status).IsRequired().HasDefaultValue(orderStatus.Pending);

        }
    }
}
