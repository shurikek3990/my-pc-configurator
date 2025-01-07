namespace MyPcConfigurator.Models
{
    public class Motherboard : Part
    {
        public string Format { get; set; }
        public string Socket { get; set; }
        public string RamType { get; set; }
        public int RamSlots { get; set; }

    }
}
