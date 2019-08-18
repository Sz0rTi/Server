using Microsoft.EntityFrameworkCore;
using DAO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAO.Context
{
    public class MagazineContext : IdentityDbContext
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
        public DbSet<TaxStage> TaxStages { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
              builder.Entity<Product>()
                .HasOne<Unit>(s => s.Unit)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.UnitID);
        }
    }
}
