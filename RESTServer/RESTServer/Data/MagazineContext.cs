using Microsoft.EntityFrameworkCore;
using RESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RESTServer.Data
{
    public class MagazineContext : DbContext
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
        }
    }
}
