using System.ComponentModel.DataAnnotations;

namespace MyPcConfigurator.Models
{
    public class PowerSupply : Part
    {
        [Required]
        public int OutputPower { get; set; }
    }
}
