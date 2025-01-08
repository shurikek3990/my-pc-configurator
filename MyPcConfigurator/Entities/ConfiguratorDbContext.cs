using Microsoft.EntityFrameworkCore;
using MyPcConfigurator.Models;

namespace MyPcConfigurator.Entities
{
    public class ConfiguratorDbContext : DbContext
    {
        public DbSet<Build> Builds { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<Memory> Memories { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PowerSupply> PowerSupplys { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        public ConfiguratorDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
