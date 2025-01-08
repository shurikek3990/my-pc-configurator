using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MyPcConfigurator.Models
{
    public class Motherboard : Part
    {
        [Required]
        [MaxLength(10)]
        [Unicode]
        public string Format { get; set; }

        [Required]
        [MaxLength(10)]
        [Unicode]
        public string Socket { get; set; }

        [Required]
        [MaxLength(10)]
        [Unicode]
        public string RamType { get; set; }

        [Required]
        public int RamSlots { get; set; }

    }
}
