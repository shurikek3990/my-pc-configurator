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
            _dbContext.Add(part);
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
    }
}
