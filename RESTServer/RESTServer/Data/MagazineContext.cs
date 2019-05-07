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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInOrder> ProductInOrders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TaxStage> TaxStages { get; set; }

    }
}
