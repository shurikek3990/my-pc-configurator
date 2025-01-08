using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyPcConfigurator.Models
{
    public class Build
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Unicode]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Motherboard Motherboard { get; set; }

        [Required]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Processor Processor { get; set; }
        public GraphicsCard? GraphicsCard { get; set; }

        [Required]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public PowerSupply PowerSupply { get; set; }

        [Required]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Disk Disk { get; set; }

        //TODO
        public List<Memory> MemoryUnits { get; set; }
    }
}
