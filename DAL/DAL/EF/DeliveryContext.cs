using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    internal class DeliveryContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DeliveryContext(DbContextOptions options) : base(options) 
        {
        }
    }
}
