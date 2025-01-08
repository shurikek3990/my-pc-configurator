using System.ComponentModel.DataAnnotations;

namespace MyPcConfigurator.Models
{
    public class Disk : Part
    {
        [Required]
        public int Capacity { get; set; }
    }
}
