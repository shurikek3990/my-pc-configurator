using MyPcConfigurator.Models;

namespace MyPcConfigurator.Abstractions
{
    public interface IPartsRepository
    {
        public Part AddPart(Part part);
        public Part UpdatePart(Part part);
        public object? GetPart(Type type, int id);
    }
}
