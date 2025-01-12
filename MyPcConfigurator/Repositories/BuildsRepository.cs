using Microsoft.EntityFrameworkCore;
using MyPcConfigurator.Abstractions;
using MyPcConfigurator.Entities;
using MyPcConfigurator.Models;

namespace MyPcConfigurator.Repositories
{
    public class BuildsRepository : IBuildsRepository
    {
        private readonly ConfiguratorDbContext _dbContext;

        public BuildsRepository(ConfiguratorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Build AddBuild(Build build)
        {
            _dbContext.Builds.Add(build);
            _dbContext.SaveChanges();
            return build;
        }

        public void DeleteBuild(Build build)
        {
            _dbContext.Builds.Remove(build);
            _dbContext.SaveChanges();
        }

        public Build GetBuild(int buildId)
        {
            var build = _dbContext.Builds
                .Include(b => b.Motherboard)
                .Include(b => b.Processor)
                .Include(b => b.GraphicsCard)
                .Include(b => b.PowerSupply)
                .Include(b => b.Disk)
                .Include(b => b.MemoryUnits)
                .First(b => b.Id == buildId);
            return build;
        }

        public List<Build> GetBuildsList()
        {
            var builds = _dbContext.Builds
                .ToList();

            return builds;
        }
    }
}
