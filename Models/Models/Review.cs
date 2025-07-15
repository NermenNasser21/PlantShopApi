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
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int? PlantId { get; set; }
        public virtual Plant Plant { get; set; }
        public int? ToolId { get; set; }
        public virtual Tool Tool { get; set; }
        public string? Comment { get; set; }
        public int? Rate { get; set; }

    }
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Plant)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.PlantId);
            builder.HasOne(x => x.Tool)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ToolId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.UserId);
        }
    }
}
