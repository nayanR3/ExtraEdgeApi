using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExtraEdgeApi.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Brand> brands { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Mobile> mobiles { get; set; }
        public DbSet<Sell> sells { get; set; }
    }
}
