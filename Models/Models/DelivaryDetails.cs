using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DelivaryDetails
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
    }
    public class DelivaryDetailsConfiguration : IEntityTypeConfiguration<DelivaryDetails>
    {
        public void Configure(EntityTypeBuilder<DelivaryDetails> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
