using Microsoft.AspNetCore.Mvc;
using MyPcConfigurator.Abstractions;
using MyPcConfigurator.Models;
using MyPcConfigurator.Repositories;

namespace MyPcConfigurator.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IVendorsRepository _vendorsRepository;
        private readonly IBuildsRepository _buildsRepository;
        public AdminPanelController(IVendorsRepository vendorsRepository, 
            IBuildsRepository buildsRepository)
        {
            _vendorsRepository = vendorsRepository;
            _buildsRepository = buildsRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetVendors()
        {
            var vendorslist = _vendorsRepository.GetVendorsList();
            return View(vendorslist);
        }
        public IActionResult AddOrUpdateVendor(int? vendorId = null)
        {
            if (vendorId == null) 
            {
                return View(new Vendor());
            }

            var vendor = _vendorsRepository.GetVendor(vendorId!.Value);
            return View(vendor);
        }
        public IActionResult AddOrUpdateVendor(Vendor vendor)
        {
            ModelState.ClearValidationState(nameof(Vendor));
            if (!TryValidateModel(vendor, nameof(Vendor)))
                return View(vendor);

            if (vendor.Id > 0)
                _vendorsRepository.UpdateVendor(vendor);
            else
                _vendorsRepository.AddVendor(vendor);
            return RedirectToAction("GetVendors");
        }

        public IActionResult GetBuilds()
        {
            var builds = _buildsRepository.GetBuildsList();
            return View(builds);
        }

        public IActionResult ViewBuild(int buildId)
        {
            var build = _buildsRepository.GetBuild(buildId);
            return View(build);
        }
    }
}
