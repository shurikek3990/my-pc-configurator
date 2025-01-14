using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyPcConfigurator.Models;

namespace MyPcConfigurator.ViewModel
{
    public class CreateBuildViewModel
    {
        public CreateBuildViewModel() => Build = new Build();

        public CreateBuildViewModel(Build build) => Build = build;

        public Build Build { get; set; }

        [DisplayName("Motherboard")]
        public string SelectedMotherboard { get; set; }

        [DisplayName("Processor")]
        public string SelectedProcessor { get; set; }

        [DisplayName("Graphics card")]
        public string? SelectedGraphicsCard { get; set; }

        [DisplayName("Disk")]
        public string SelectedDisk { get; set; }

        [DisplayName("Power supply")]
        public string SelectedPowerSupply { get; set; }

        [DisplayName("RAM memory")]
        public List<string> SelectedMemoryUnits { get; set; }


        public List<SelectListItem> ProcessorListItems { get; set; }
        public List<SelectListItem> MotherboardListItems { get; set; }
        public List<SelectListItem> GraphicsCardsListItems { get; set; }
        public List<SelectListItem> DiskListItems { get; set; }
        public List<SelectListItem> PowerSuppliesListItems { get; set; }
        public List<SelectListItem> MemoryUnitsListItems { get; set; }

    }
}
