using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleRentalApp.Data;
using VehicleRentalApp.Models;
using VehicleRentalApp.Repositories;
using VehicleRentalApp.Repositories.Interfaces;
using VehicleRentalApp.ViewModels;

namespace VehicleRentalApp.Controllers
{
    public class EquipmentTypesController : Controller
    {
        private readonly IEquipmentTypeRepository _equipmentTypeRepository;
        private readonly IMapper _mapper;

        public EquipmentTypesController(IEquipmentTypeRepository equipmentTypeRepository, IMapper mapper)
        {
            _equipmentTypeRepository = equipmentTypeRepository;
            _mapper = mapper;
        }

        // GET: EquipmentTypes
        public async Task<IActionResult> Index()
        {
            var types = await _equipmentTypeRepository.GetAllAsync();
            var viewModels = _mapper.Map<List<EquipmentTypeViewModel>>(types);
            return View(viewModels);
        }

        // GET: EquipmentTypes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var type = await _equipmentTypeRepository.GetByIdAsync(id);
            if (type == null)
                return NotFound();

            var viewModel = _mapper.Map<EquipmentTypeViewModel>(type);
            return View(viewModel);
        }

        // GET: EquipmentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipmentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] EquipmentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var type = _mapper.Map<EquipmentType>(model);
                await _equipmentTypeRepository.AddAsync(type);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: EquipmentTypes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var type = await _equipmentTypeRepository.GetByIdAsync(id);
            if (type == null)
                return NotFound();

            var viewModel = _mapper.Map<EquipmentTypeViewModel>(type);
            return View(viewModel);
        }

        // POST: EquipmentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] EquipmentTypeViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var type = _mapper.Map<EquipmentType>(model);
                await _equipmentTypeRepository.UpdateAsync(type);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: EquipmentTypes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var type = await _equipmentTypeRepository.GetByIdAsync(id);
            if (type == null)
                return NotFound();

            var viewModel = _mapper.Map<EquipmentTypeViewModel>(type);
            return View(viewModel);
        }

        // POST: EquipmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _equipmentTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RentalPointExists(int id)
        {
            return await _equipmentTypeRepository.ExistAsync(id);
        }
    }
}
