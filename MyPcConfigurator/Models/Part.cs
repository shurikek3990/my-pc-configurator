using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyPcConfigurator.Models
{
    public abstract class Part
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode]
        public string ModelName { get; set; }

        [Required]
        public int PowerConsumption { get; set; }

        [Required]
        [Precision(5,2)]
        public decimal Price { get; set; }

        [Required]
        public Vendor Vendor { get; set; }
    }
}
