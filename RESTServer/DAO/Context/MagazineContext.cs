using Microsoft.EntityFrameworkCore;
using DAO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAO.Context
{
    public class MagazineContext : IdentityDbContext<ApplicationUser>
    {
        public MagazineContext(DbContextOptions<MagazineContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InvoiceBuy> InvoicesBuy { get; set; }
        public DbSet<InvoiceSell> InvoicesSell { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBuy> ProductsBuy { get; set; }
        public DbSet<ProductSell> ProductsSell { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public Task<object> FirstOrDefaultAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<TaxStage> TaxStages { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
              builder.Entity<Product>()
                .HasOne<Unit>(s => s.Unit)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.UnitID);

            builder.Entity<IdentityRole>()
                   .HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                   new IdentityRole("Admin"));
        }
    }
}
