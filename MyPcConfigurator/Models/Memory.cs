namespace MyPcConfigurator.Models
{
    public class Memory : Part
    {
        public int Capacity { get; set; }
        public string RamType { get; set; }
        public virtual List<RamToBuild> Builds { get; set; }
    }
}
