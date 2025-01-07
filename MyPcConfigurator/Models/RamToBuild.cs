namespace MyPcConfigurator.Models
{
    public class RamToBuild
    {
        public int Id { get; set; }
        public int BuildId { get; set; }
        public virtual Build Build { get; set; }
        public int MemoryId { get; set; }
        public virtual Memory Memory { get; set; }
    }
}
