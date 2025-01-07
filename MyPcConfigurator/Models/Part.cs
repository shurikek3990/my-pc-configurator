namespace MyPcConfigurator.Models
{
    public abstract class Part
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int PowerConsumption { get; set; }
        public decimal Price { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
