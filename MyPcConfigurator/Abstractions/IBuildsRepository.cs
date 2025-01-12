using MyPcConfigurator.Models;

namespace MyPcConfigurator.Abstractions
{
    public interface IBuildsRepository
    {
        public Build AddBuild(Build build);
        public void DeleteBuild(Build build);
        public List<Build> GetBuildsList();
        public Build GetBuild(int buildId);
    }
}
