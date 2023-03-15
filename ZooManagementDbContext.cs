using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) { }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Species> Species { get; set; }
    }
}