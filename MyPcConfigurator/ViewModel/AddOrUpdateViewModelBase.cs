using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyPcConfigurator.ViewModel
{
    public abstract class AddOrUpdateViewModelBase
    {
        public List<SelectListItem> VendorsToSelectList { get; set; }

        [Required]
        public string SelectedVendor { get; set; }
    }
}
