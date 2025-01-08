using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyPcConfigurator.Models
{
    public class Processor : Part
    {
        [Required]
        [MaxLength(10)]
        [Unicode]
        public string Socket { get; set; }

        [Required]
        public int Cores { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool IntegratedGraphics { get; set; }
    }
}
