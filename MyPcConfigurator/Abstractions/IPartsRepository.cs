using MyPcConfigurator.Models;

namespace MyPcConfigurator.Abstractions
{
    public interface IPartsRepository
    {
        public Part AddPart(Part part);
        public Part UpdatePart(Part part);
        public object? GetPart(Type type, int id);

        public List<Motherboard> GetMotherboards();
        public Motherboard GetMotherboardById(int id);
        public List<Processor> GetProcessors();
        public Processor GetProcessorById(int id);
        public List<Disk> GetDisks();
        public Disk GetDiskById(int id);
        public List<PowerSupply> GetPowerSupplies();
        public PowerSupply GetPowerSupplyById(int id);
        public List<Memory> GetMemories();
        public Memory GetMemoryById(int id);
        public List<GraphicsCard> GetGraphicsCards();
        public GraphicsCard GetGraphicsCardById(int id);
    }
}
