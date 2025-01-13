using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyPcConfigurator.Models;

namespace MyPcConfigurator.ViewModel
{
    public class AddOrUpdateMotherboardViewModel
    {
        public Motherboard Motherboard { get; set; }

        
        public List<SelectListItem> VendorsToSelectList { get; set; }

        [Required]
        public string SelectedVendor { get; set; }
    }
}
