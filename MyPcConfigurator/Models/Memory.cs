using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MyPcConfigurator.Models
{
    public class Memory : Part
    {
        [Required]
        public int Capacity { get; set; }

        [Required]
        [MaxLength(10)]
        [Unicode]
        public string RamType { get; set; }
        public List<Build> Builds { get; set; }
    }
}
