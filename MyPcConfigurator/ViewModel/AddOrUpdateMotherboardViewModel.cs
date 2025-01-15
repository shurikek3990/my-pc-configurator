using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyPcConfigurator.Models;

namespace MyPcConfigurator.ViewModel
{
    public class AddOrUpdateMotherboardViewModel : AddOrUpdateViewModelBase
    {
        public Motherboard Motherboard { get; set; }
    }
}
