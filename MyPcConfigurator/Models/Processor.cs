namespace MyPcConfigurator.Models
{
    public class Processor : Part
    {
        public string Socket { get; set; }
        public int Cores { get; set; }
        public bool IntegratedGraphics { get; set; }
    }
}
