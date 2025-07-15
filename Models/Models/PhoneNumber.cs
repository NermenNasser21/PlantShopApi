using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string UserId { set; get; }
        public virtual User User { get; set; }
        public string Number { set; get; }

    }

    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.PhoneNumbers)
                .HasForeignKey(x => x.UserId);
        }
    }
}
