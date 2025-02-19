﻿using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using MyPcConfigurator.Abstractions;
using MyPcConfigurator.Models;
using MyPcConfigurator.Repositories;
using MyPcConfigurator.ViewModel;

namespace MyPcConfigurator.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IVendorsRepository _vendorsRepository;
        private readonly IBuildsRepository _buildsRepository;
        private readonly IPartsRepository _partsRepository;
        public AdminPanelController(IVendorsRepository vendorsRepository, 
            IBuildsRepository buildsRepository,
            IPartsRepository partsRepository)
        {
            _vendorsRepository = vendorsRepository;
            _buildsRepository = buildsRepository;
            _partsRepository = partsRepository;
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

        [HttpGet]
        public IActionResult AddOrUpdateVendor(int? vendorId = null)
        {
            if (vendorId == null) 
            {
                return View(new Vendor());
            }

            var vendor = _vendorsRepository.GetVendor(vendorId!.Value);
            return View(vendor);
        }

        [HttpPost]
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

        public IActionResult GetMotherboards()
        {
            var motherboards = _partsRepository.GetMotherboards();
            return View(motherboards);
        }

        [HttpGet]
        public IActionResult AddOrUpdateMotherboard(int? motherboardId = null)
        {
            AddOrUpdateMotherboardViewModel viewModel;
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            if (motherboardId == null)
            {
                viewModel = new AddOrUpdateMotherboardViewModel { 
                    Motherboard = new Motherboard(), 
                    VendorsToSelectList = selectList
                };
                return View(viewModel);
            }

            var motherboard = _partsRepository.GetMotherboardById(motherboardId.Value);
            viewModel = new AddOrUpdateMotherboardViewModel
            {
                Motherboard = motherboard,
                VendorsToSelectList = selectList,
                SelectedVendor = selectList.FirstOrDefault(i => i.Value == motherboard.Vendor.Id.ToString())!.Value
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrUpdateMotherboard(AddOrUpdateMotherboardViewModel model)
        {
            var vendors = _vendorsRepository.GetVendorsList();
            model.Motherboard.Vendor = vendors.First(v => v.Id.ToString() == model.SelectedVendor);
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            model.VendorsToSelectList = selectList;

            if (model.Motherboard.Id > 0)
                _partsRepository.UpdatePart(model.Motherboard);
            else
                _partsRepository.AddPart(model.Motherboard);

            return RedirectToAction("GetMotherboards");
        }

        public IActionResult GetProcessors()
        {
            var processors = _partsRepository.GetProcessors();
            return View(processors);
        }

        [HttpGet]
        public IActionResult AddOrUpdateProcessor(int? processorId = null)
        {
            AddOrUpdateProcessorViewModel viewModel;
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            if (processorId == null)
            {
                viewModel = new AddOrUpdateProcessorViewModel
                {
                    Processor = new Processor(),
                    VendorsToSelectList = selectList
                };
                return View(viewModel);
            }

            var processor = _partsRepository.GetProcessorById(processorId.Value);
            viewModel = new AddOrUpdateProcessorViewModel
            {
                Processor = processor,
                VendorsToSelectList = selectList,
                SelectedVendor = selectList.FirstOrDefault(i => i.Value == processor.Vendor.Id.ToString())!.Value
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrUpdateProcessor(AddOrUpdateProcessorViewModel model)
        {
            var vendors = _vendorsRepository.GetVendorsList();
            model.Processor.Vendor = vendors.First(v => v.Id.ToString() == model.SelectedVendor);
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            model.VendorsToSelectList = selectList;

            if (model.Processor.Id > 0)
                _partsRepository.UpdatePart(model.Processor);
            else
                _partsRepository.AddPart(model.Processor);

            return RedirectToAction("GetProcessors");
        }

        public IActionResult GetDisks()
        {
            var disks = _partsRepository.GetDisks();
            return View(disks);
        }

        [HttpGet]
        public IActionResult AddOrUpdateDisk(int? diskId = null)
        {
            AddOrUpdateDiskViewModel viewModel;
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            if (diskId == null)
            {
                viewModel = new AddOrUpdateDiskViewModel
                {
                    Disk = new Disk(),
                    VendorsToSelectList = selectList
                };
                return View(viewModel);
            }

            var disk = _partsRepository.GetDiskById(diskId.Value);
            viewModel = new AddOrUpdateDiskViewModel
            {
                Disk = disk,
                VendorsToSelectList = selectList,
                SelectedVendor = selectList.FirstOrDefault(v => v.Value == disk.Vendor.Id.ToString())!.Value
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrUpdateDisk(AddOrUpdateDiskViewModel model)
        {
            var vendors = _vendorsRepository.GetVendorsList();
            model.Disk.Vendor = vendors.First(v => v.Id.ToString() == model.SelectedVendor);
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            model.VendorsToSelectList = selectList;

            if (model.Disk.Id > 0)
                _partsRepository.UpdatePart(model.Disk);
            else
                _partsRepository.AddPart(model.Disk);

            return RedirectToAction("GetDisks");
        }

        public IActionResult GetMemory()
        {
            var memoryList = _partsRepository.GetMemories();
            return View(memoryList);
        }

        [HttpGet]
        public IActionResult AddOrUpdateMemory(int? memoryId = null)
        {
            AddOrUpdateMemoryViewModel viewModel;
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            if (memoryId == null)
            {
                viewModel = new AddOrUpdateMemoryViewModel
                {
                    Memory = new Memory(),
                    VendorsToSelectList = selectList
                };
                return View(viewModel);
            }

            var memory = _partsRepository.GetMemoryById(memoryId.Value);
            viewModel = new AddOrUpdateMemoryViewModel
            {
                Memory = memory,
                VendorsToSelectList = selectList,
                SelectedVendor = selectList.FirstOrDefault(v => v.Value == memory.Vendor.Id.ToString())!.Value
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrUpdateMemory(AddOrUpdateMemoryViewModel model)
        {
            var vendors = _vendorsRepository.GetVendorsList();
            model.Memory.Vendor = vendors.First(v => v.Id.ToString() == model.SelectedVendor);
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            model.VendorsToSelectList = selectList;

            if (model.Memory.Id > 0)
                _partsRepository.UpdatePart(model.Memory);
            else
                _partsRepository.AddPart(model.Memory);

            return RedirectToAction("GetMemory");
        }

        public IActionResult GetGraphicsCards()
        {
            var graphicsCards = _partsRepository.GetGraphicsCards();
            return View(graphicsCards);
        }

        [HttpGet]
        public IActionResult AddOrUpdateGraphicsCard(int? graphicsCardId = null)
        {
            AddOrUpdateGraphicsCardViewModel viewModel;
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            if (graphicsCardId == null)
            {
                viewModel = new AddOrUpdateGraphicsCardViewModel
                {
                    GraphicsCard = new GraphicsCard(),
                    VendorsToSelectList = selectList
                };
                return View(viewModel);
            }

            var graphicsCard = _partsRepository.GetGraphicsCardById(graphicsCardId.Value);
            viewModel = new AddOrUpdateGraphicsCardViewModel
            {
                GraphicsCard = graphicsCard,
                VendorsToSelectList = selectList,
                SelectedVendor = selectList.FirstOrDefault(v => v.Value == graphicsCard.Vendor.Id.ToString())!.Value
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrUpdateGraphicsCard(AddOrUpdateGraphicsCardViewModel model)
        {
            var vendors = _vendorsRepository.GetVendorsList();
            model.GraphicsCard.Vendor = vendors.First(v => v.Id.ToString() == model.SelectedVendor);
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            model.VendorsToSelectList = selectList;

            if (model.GraphicsCard.Id > 0)
                _partsRepository.UpdatePart(model.GraphicsCard);
            else
                _partsRepository.AddPart(model.GraphicsCard);

            return RedirectToAction("GetGraphicsCards");
        }

        public IActionResult GetPowerSupplies()
        {
            var supplies = _partsRepository.GetPowerSupplies();
            return View(supplies);
        }

        [HttpGet]
        public IActionResult AddOrUpdatePowerSupply(int? powerSupplyId = null)
        {
            AddOrUpdatePowerSupplyViewModel viewModel;
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            if (powerSupplyId == null)
            {
                viewModel = new AddOrUpdatePowerSupplyViewModel
                {
                    PowerSupply = new PowerSupply(),
                    VendorsToSelectList = selectList
                };
                return View(viewModel);
            }

            var powerSupply = _partsRepository.GetPowerSupplyById(powerSupplyId.Value);
            viewModel = new AddOrUpdatePowerSupplyViewModel
            {
                PowerSupply = powerSupply,
                VendorsToSelectList = selectList,
                SelectedVendor = selectList.FirstOrDefault(v => v.Value == powerSupply.Vendor.Id.ToString())!.Value
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrUpdatePowerSupply(AddOrUpdatePowerSupplyViewModel model)
        {
            var vendors = _vendorsRepository.GetVendorsList();
            model.PowerSupply.Vendor = vendors.First(v => v.Id.ToString() == model.SelectedVendor);
            var selectList = _vendorsRepository.GetVendorsAsSelectListItems();
            model.VendorsToSelectList = selectList;

            if (model.PowerSupply.Id > 0)
                _partsRepository.UpdatePart(model.PowerSupply);
            else
                _partsRepository.AddPart(model.PowerSupply);

            return RedirectToAction("GetPowerSupplies");
        }
    }
}
