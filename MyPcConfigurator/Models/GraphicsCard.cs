using System.ComponentModel.DataAnnotations;

namespace MyPcConfigurator.Models
{
    public class GraphicsCard : Part
    {
        [Required]
        public int Memory { get; set; }
    }
}
