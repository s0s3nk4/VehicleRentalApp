using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleRentalApp.Models;
using VehicleRentalApp.Repositories.Interfaces;
using VehicleRentalApp.ViewModels;

namespace VehicleRentalApp.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentsController(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _equipmentRepository = equipmentRepository;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var equipments = await _equipmentRepository.GetAllAsync();
            var viewModels = _mapper.Map<List<EquipmentItemViewModel>>(equipments);
            return View(viewModels);
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment == null)
                return NotFound();

            var viewModel = _mapper.Map<EquipmentDetailViewModel>(equipment);
            return View(viewModel);
        }

        // GET: Equipments/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EquipmentTypeId"] = new SelectList(await _equipmentRepository.GetEquipmentTypesAsync(), "Id", "Name");
            ViewData["RentalPointId"] = new SelectList(await _equipmentRepository.GetRentalPointsAsync(), "Id", "Address");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Name,Type,Year,Description,PricePerDay,ImageUrl,EquipmentTypeId")] EquipmentDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var equipment = _mapper.Map<Equipment>(model);
                await _equipmentRepository.AddAsync(equipment);
                return RedirectToAction(nameof(Index));
            }

            ViewData["EquipmentTypeId"] = new SelectList(await _equipmentRepository.GetEquipmentTypesAsync(), "Id", "Name", model.EquipmentTypeId);
            ViewData["RentalPointId"] = new SelectList(await _equipmentRepository.GetRentalPointsAsync(), "Id", "Address", model.RentalPointId);
            return View(model);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment == null)
                return NotFound();

            var viewModel = _mapper.Map<EquipmentDetailViewModel>(equipment);
            ViewData["EquipmentTypeId"] = new SelectList(await _equipmentRepository.GetEquipmentTypesAsync(), "Id", "Name", viewModel.EquipmentTypeId);
            ViewData["RentalPointId"] = new SelectList(await _equipmentRepository.GetRentalPointsAsync(), "Id", "Address", viewModel.RentalPointId);
            return View(viewModel);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Name,Type,Year,Description,PricePerDay,ImageUrl,EquipmentTypeId")] EquipmentDetailViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var equipment = _mapper.Map<Equipment>(model);
                await _equipmentRepository.UpdateAsync(equipment);
                return RedirectToAction(nameof(Index));
            }

            ViewData["EquipmentTypeId"] = new SelectList(await _equipmentRepository.GetEquipmentTypesAsync(), "Id", "Name", model.EquipmentTypeId);
            ViewData["RentalPointId"] = new SelectList(await _equipmentRepository.GetRentalPointsAsync(), "Id", "Address", model.RentalPointId);
            return View(model);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment == null)
                return NotFound();

            var viewModel = _mapper.Map<EquipmentDetailViewModel>(equipment);
            return View(viewModel);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _equipmentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EquipmentExists(int id)
        {
            return await _equipmentRepository.ExistAsync(id);
        }
    }
}
