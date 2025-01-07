namespace MyPcConfigurator.Models
{
    public class Build
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public int MotherboardId { get; set; }
        public virtual Motherboard Motherboard { get; set; }
        public int ProccesorId { get; set; }
        public virtual Processor Processor { get; set; }
        public int? GraphicsCardId { get; set; }
        public virtual GraphicsCard? GraphicsCard { get; set; }
        public int PowerSupplyId { get; set; }
        public virtual PowerSupply PowerSupply { get; set; }
        public int DiskId { get; set; }
        public virtual Disk Disk { get; set; }
        public virtual List<RamToBuild> RamToBuild { get; set; }
    }
}
