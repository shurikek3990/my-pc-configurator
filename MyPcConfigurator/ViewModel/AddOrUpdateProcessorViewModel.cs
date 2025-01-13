using Microsoft.AspNetCore.Mvc.Rendering;
using MyPcConfigurator.Models;
using System.ComponentModel.DataAnnotations;

namespace MyPcConfigurator.ViewModel
{
    public class AddOrUpdateProcessorViewModel
    {
        public Processor Processor { get; set; }


        public List<SelectListItem> VendorsToSelectList { get; set; }

        [Required]
        public string SelectedVendor { get; set; }
    }
}
