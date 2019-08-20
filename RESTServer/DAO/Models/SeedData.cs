using DAO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MagazineContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MagazineContext>>()))
            {
                if (context.Clients.Any())
                {
                    return;   // DB has been seeded
                }
            }
        }
    }
}
