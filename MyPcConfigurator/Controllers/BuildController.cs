﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyPcConfigurator.Abstractions;
using MyPcConfigurator.Models;
using MyPcConfigurator.ViewModel;

namespace MyPcConfigurator.Controllers
{
    public class BuildController : Controller
    {
        private readonly IPartsRepository _partsRepository;
        private readonly IBuildsRepository _buildsRepository;
        public BuildController(IPartsRepository partsRepository, IBuildsRepository buildsRepository)
        {
            _partsRepository = partsRepository;
            _buildsRepository = buildsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateBuildViewModel();
            model = FillListItems(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateBuildViewModel model)
        {
            model = FillListItems(model);

            var motherboard = model.SelectedMotherboard != "" && model.SelectedMotherboard != null
                ? _partsRepository.GetPart(typeof(Motherboard), int.Parse(model.SelectedMotherboard)) as Motherboard
                : null;
            var processor = model.SelectedProcessor != "" && model.SelectedProcessor != null
                ? _partsRepository.GetPart(typeof(Processor), int.Parse(model.SelectedProcessor)) as Processor
                : null;
            var disk = model.SelectedDisk != "" && model.SelectedDisk != null
                ? _partsRepository.GetPart(typeof(Disk), int.Parse(model.SelectedDisk)) as Disk
                : null;
            var graphicsCard = model.SelectedGraphicsCard != "" && model.SelectedGraphicsCard != null
                ? _partsRepository.GetPart(typeof(GraphicsCard), int.Parse(model.SelectedGraphicsCard)) as GraphicsCard
                : null;
            var powerSupply = model.SelectedPowerSupply != "" && model.SelectedPowerSupply != null
                ? _partsRepository.GetPart(typeof(PowerSupply), int.Parse(model.SelectedPowerSupply)) as PowerSupply
                : null;
            var memoryUnits = new List<Memory>();
            foreach(var selMem in model.SelectedMemoryUnits)
            {
                if (selMem == "" || selMem == null)
                    continue;
                var mem = _partsRepository.GetPart(typeof(Memory), int.Parse(selMem)) as Memory;
                if (mem != null)
                    memoryUnits.Add(mem);
            }

            ModelState.Clear();

            if (motherboard == null)
                ModelState.AddModelError(nameof(model.SelectedMotherboard),
                    "Motherboard was not selected");

            if (processor == null)
                ModelState.AddModelError(nameof(model.SelectedProcessor),
                    "Processor was not selected");

            if (disk == null)
                ModelState.AddModelError(nameof(model.SelectedDisk),
                    "Disk was not selected");

            if (powerSupply == null)
                ModelState.AddModelError(nameof(model.SelectedDisk),
                    "Power supply was not selected");

            if (motherboard?.Socket != processor?.Socket)
            {
                ModelState.AddModelError(nameof(model.SelectedProcessor), 
                    "Incompatible socket types between Motherboard and Processor");
            }

            if (memoryUnits.Count == 0) 
            {
                ModelState.AddModelError(nameof(model.SelectedMemoryUnits),
                    "No memory was selected");
            }

            if (memoryUnits.Count > (motherboard?.RamSlots ?? 0))
            {
                ModelState.AddModelError(nameof(model.SelectedMemoryUnits),
                    $"Too much memory units selected. Your motherboards has only {motherboard?.RamSlots ?? 0} slots.");
            }

            if (memoryUnits.Any(mem => mem.RamType != motherboard?.RamType))
            {
                ModelState.AddModelError(nameof(model.SelectedMemoryUnits),
                    $"One or multiple RAM units are of incompatible RAM type. Please, select RAM units of {motherboard?.RamType} type");
            }

            int powerConsumption = 
                (motherboard?.PowerConsumption ?? 0) 
                + (processor?.PowerConsumption ?? 0) 
                + (graphicsCard?.PowerConsumption ?? 0) 
                + (disk?.PowerConsumption ?? 0);
            foreach (var mem in memoryUnits)
                powerConsumption += mem?.PowerConsumption ?? 0;
            if (powerConsumption > (powerSupply?.OutputPower ?? 0))
            {
                ModelState.AddModelError(nameof(model.SelectedPowerSupply),
                    "Power supply is too weak.");
            }

            if (graphicsCard == null && processor?.IntegratedGraphics == false)
            {
                ModelState.AddModelError(nameof(model.SelectedGraphicsCard),
                    "Processor has no integrated graphics and no graphics card was selected.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Build.Motherboard = motherboard!;
            model.Build.Processor = processor!;
            model.Build.GraphicsCard = graphicsCard;
            model.Build.Disk = disk!;
            model.Build.PowerSupply = powerSupply!;
            model.Build.MemoryUnits = memoryUnits;

            TempData["build"] = JsonSerializer.Serialize(model.Build);

            return RedirectToAction("CheckBuild");
        }
         
        public IActionResult CheckBuild()
        {
            var json = TempData["build"] as string;
            var build = JsonSerializer.Deserialize<Build>(json);
            return View(build);
        }

        public IActionResult AddBuild(Build build)
        {
            var json = TempData["build"] as string;
            var trueBuild = JsonSerializer.Deserialize<Build>(json);
            trueBuild.Email = build.Email;

            trueBuild.CreatedAt = DateTime.Now;
            _buildsRepository.AddBuild(trueBuild);
            return RedirectToAction("Index");
        }

        private CreateBuildViewModel FillListItems(CreateBuildViewModel model)
        {
            var motherboardListItems = _partsRepository.GetMotherboards()
                .Select(m => new SelectListItem($"{m.Vendor.Name} - {m.ModelName}", m.Id.ToString()))
                .Prepend(new SelectListItem("", ""))
                .ToList();
            var processorListItems = _partsRepository.GetProcessors()
                .Select(m => new SelectListItem($"{m.Vendor.Name} - {m.ModelName}", m.Id.ToString()))
                .Prepend(new SelectListItem("", ""))
                .ToList();
            var diskListItems = _partsRepository.GetDisks()
                .Select(m => new SelectListItem($"{m.Vendor.Name} - {m.ModelName}", m.Id.ToString()))
                .Prepend(new SelectListItem("", ""))
                .ToList();
            var powerSuppliesListItems = _partsRepository.GetPowerSupplies()
                .Select(m => new SelectListItem($"{m.Vendor.Name} - {m.ModelName}", m.Id.ToString()))
                .Prepend(new SelectListItem("", ""))
                .ToList();
            var graphicsCardsListItems = _partsRepository.GetGraphicsCards()
                .Select(m => new SelectListItem($"{m.Vendor.Name} - {m.ModelName}", m.Id.ToString()))
                .Prepend(new SelectListItem("", ""))
                .ToList();
            var memoryUnitsListItems = _partsRepository.GetMemories()
                .Select(m => new SelectListItem($"{m.Vendor.Name} - {m.ModelName}", m.Id.ToString()))
                .Prepend(new SelectListItem("", ""))
                .ToList();

            model.MotherboardListItems = motherboardListItems;
            model.ProcessorListItems = processorListItems;
            model.DiskListItems = diskListItems;
            model.PowerSuppliesListItems = powerSuppliesListItems;
            model.GraphicsCardsListItems = graphicsCardsListItems;
            model.MemoryUnitsListItems = memoryUnitsListItems;

            return model;
        }
    }
}
