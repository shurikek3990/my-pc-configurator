using MyPcConfigurator.Models;

namespace MyPcConfigurator.Abstractions
{
    public interface IVendorsRepository
    {
        public List<Vendor> GetVendorsList(int pageNum = 1);
        public Vendor GetVendor(int id);
        public Vendor AddVendor(Vendor vendor);
        public Vendor UpdateVendor(Vendor vendor);
        public void DeleteVendor(Vendor vendor);
    }
}
