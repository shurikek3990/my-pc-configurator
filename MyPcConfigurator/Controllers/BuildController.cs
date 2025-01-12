using Microsoft.AspNetCore.Mvc;
using MyPcConfigurator.Abstractions;

namespace MyPcConfigurator.Controllers
{
    public class BuildController : Controller
    {
        private readonly IPartsRepository _partsRepository;
        public BuildController(IPartsRepository partsRepository)
        {
            _partsRepository = partsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
