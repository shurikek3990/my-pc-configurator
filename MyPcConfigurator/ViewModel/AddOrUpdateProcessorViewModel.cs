using Microsoft.AspNetCore.Mvc.Rendering;
using MyPcConfigurator.Models;
using System.ComponentModel.DataAnnotations;

namespace MyPcConfigurator.ViewModel
{
    public class AddOrUpdateProcessorViewModel : AddOrUpdateViewModelBase
    {
        public Processor Processor { get; set; }
    }
}
