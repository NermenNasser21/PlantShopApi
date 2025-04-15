using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class User :IdentityUser
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? CartId { get; set; }
        public virtual Cart Cart {  get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }





    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Password)
                .IsRequired();

            builder.Property(b => b.Email)
                .IsRequired();

            builder.HasOne(b => b.Cart)
                  .WithOne(ub => ub.User)
                  .HasForeignKey<User>(b=>b.CartId);

        }
    }
 }
