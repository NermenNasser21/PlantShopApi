using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure
{
    public class PlantContext : IdentityDbContext<User>
    {
        public PlantContext(DbContextOptions<PlantContext> options):base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlantConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartProductConfiguration());
            modelBuilder.ApplyConfiguration(new DelivaryDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderedProductConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ToolConfiguration());
            modelBuilder.ApplyConfiguration(new ToolUsageConfiguration());
            modelBuilder.ApplyConfiguration(new PlantEnvironmentConfiguration());
            modelBuilder.ApplyConfiguration(new PlantGrowthConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());


            base.OnModelCreating(modelBuilder);

            //Seeding

            modelBuilder.Entity<ToolUsage>().HasData(
     new ToolUsage { Id = 1, Name = "أسمدة" },
     new ToolUsage { Id = 2, Name = "أصص" },
     new ToolUsage { Id = 3, Name = "أدوات الحماية" },
     new ToolUsage { Id = 4, Name = "أدوات الري" },
     new ToolUsage { Id = 5, Name = "أدوات الحفر" },
     new ToolUsage { Id = 6, Name = "أدوات التقليم" }
 );

            modelBuilder.Entity<PlantUsage>().HasData(
                new PlantUsage { Id = 1, Name = "نباتات عطرية" },
                new PlantUsage { Id = 2, Name = "نباتات طبية" },
                new PlantUsage { Id = 3, Name = "نباتات زينة" },
                new PlantUsage { Id = 4, Name = "خضر" },
                new PlantUsage { Id = 5, Name = "فاكهة" },
                new PlantUsage { Id = 6, Name = "حبوب" }
            );

            modelBuilder.Entity<PlantGrowth>().HasData(
                new PlantGrowth { Id = 1, Name = "أشجار" },
                new PlantGrowth { Id = 2, Name = "شجيرات" },
                new PlantGrowth { Id = 3, Name = "أزهار" },
                new PlantGrowth { Id = 4, Name = "النباتات المتسلقة" },
                new PlantGrowth { Id = 5, Name = "النباتات الزاحفة" }
            );

            modelBuilder.Entity<PlantEnvironment>().HasData(
                new PlantEnvironment { Id = 1, Name = "النباتات الداخلية" },
                new PlantEnvironment { Id = 2, Name = "النباتات الخارجية" }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "static-value-123" }  // Use static Id & ConcurrencyStamp
            );

        }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<Tool> Tools { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<ToolUsage> ToolUsages { get; set; }
        public virtual DbSet<PlantEnvironment> PlantEnvironments { get; set; }
        public virtual DbSet<PlantGrowth> PlantGrowths { get; set; }
        public virtual DbSet<PlantUsage> PlantUsages { get; set; }

        public virtual DbSet<CartProduct> CartProducts { get; set; }

        public virtual DbSet<DelivaryDetails> DelivaryDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

    }
}
