using Microsoft.EntityFrameworkCore;
using MyPcConfigurator.Abstractions;
using MyPcConfigurator.Entities;
using MyPcConfigurator.Models;

namespace MyPcConfigurator.Repositories
{
    public class PartsRepository : IPartsRepository
    {
        private readonly ConfiguratorDbContext _dbContext;
        public PartsRepository(ConfiguratorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Part AddPart(Part part)
        {
            //If .Add() => SqlException - IDENTITY_INSERT IS OFF
            //(probably EF tries to create Vendor with existing ID instead of just writing FK to Part)
            _dbContext.Update(part);
            _dbContext.SaveChanges();
            return part;
        }

        public object? GetPart(Type type, int id)
        {
            var part = _dbContext.Find(type, id);
            return part;
        }

        public Part UpdatePart(Part part)
        {
            _dbContext.Update(part);
            _dbContext.SaveChanges();
            return part;
        }

        public List<Motherboard> GetMotherboards()
        {
            var list = _dbContext.Motherboards
                .Include(m => m.Vendor)
                .ToList();

            return list;
        }

        public Motherboard GetMotherboardById(int id)
        {
            var motherboard = _dbContext.Motherboards
                .Include(m => m.Vendor)
                .First(m => m.Id == id);

            return motherboard;
        }

        public List<Processor> GetProcessors()
        {
            var processors = _dbContext.Processors
                .Include(m => m.Vendor)
                .ToList();

            return processors;
        }

        public Processor GetProcessorById(int id)
        {
            var processor = _dbContext.Processors
                .Include(m => m.Vendor)
                .First(m => m.Id == id);

            return processor;
        }

        public List<Disk> GetDisks()
        {
            var disks = _dbContext.Disks
                .Include(m => m.Vendor)
                .ToList();
            return disks;
        }

        public List<PowerSupply> GetPowerSupplies()
        {
            var powerSupplies = _dbContext.PowerSupplys
                .Include(m => m.Vendor)
                .ToList();
            return powerSupplies;
        }

        public List<Memory> GetMemories()
        {
            var memoryUnits = _dbContext.Memories
                .Include(m => m.Vendor)
                .ToList();
            return memoryUnits;
        }

        public List<GraphicsCard> GetGraphicsCards()
        {
            var graphicsCards = _dbContext.GraphicsCards
                .Include(m => m.Vendor)
                .ToList();
            return graphicsCards;
        }

        public Disk GetDiskById(int id)
        {
            var disk = _dbContext.Disks
                .Include(d => d.Vendor)
                .First (d => d.Id == id);
            return disk;
        }

        public Memory GetMemoryById(int id)
        {
            var memory = _dbContext.Memories
                .Include(m => m.Vendor)
                .First(m => m.Id == id);
            return memory;
        }

        public GraphicsCard GetGraphicsCardById(int id)
        {
            var graphicsCard = _dbContext.GraphicsCards
                .Include(gpu => gpu.Vendor)
                .First(gpu => gpu.Id == id);
            return graphicsCard;
        }

        public PowerSupply GetPowerSupplyById(int id)
        {
            var powerSupply = _dbContext.PowerSupplys
                .Include(psu => psu.Vendor)
                .First(psu => psu.Id == id);
            return powerSupply;
        }
    }
}
