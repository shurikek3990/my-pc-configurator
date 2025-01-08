using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyPcConfigurator.Models
{
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [Unicode]
        public string LegalName { get; set; }

        [Required]
        [MaxLength(5)]
        [Unicode]
        public string CountryCode { get; set; }
    }
}
