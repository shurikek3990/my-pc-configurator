using MyPcConfigurator.Abstractions;
using MyPcConfigurator.Entities;
using MyPcConfigurator.Models;

namespace MyPcConfigurator.Repositories
{
    public class VendorsRepository : IVendorsRepository
    {
        private readonly ConfiguratorDbContext _dbContext;

        public VendorsRepository(ConfiguratorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Vendor AddVendor(Vendor vendor)
        {
            _dbContext.Vendors.Add(vendor);
            _dbContext.SaveChanges();
            return vendor;
        }

        public void DeleteVendor(Vendor vendor)
        {
            throw new NotImplementedException();
        }

        public Vendor GetVendor(int id)
        {
            var vendor = _dbContext.Vendors.First(v => v.Id == id);
            return vendor;
        }

        public List<Vendor> GetVendorsList()
        {
            var vendorlist = _dbContext.Vendors
                .ToList();
            return vendorlist;
        }

        public Vendor UpdateVendor(Vendor vendor)
        {
            _dbContext.Vendors.Update(vendor);
            _dbContext.SaveChanges();
            return vendor;
        }
    }
}
