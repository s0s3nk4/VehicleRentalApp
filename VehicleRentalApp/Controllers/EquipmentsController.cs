using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleRentalApp.Models;
using VehicleRentalApp.Repositories.Interfaces;
using VehicleRentalApp.ViewModels;

namespace VehicleRentalApp.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentsController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var equipments = await _equipmentRepository.GetAllAsync();

            var viewModels = equipments.Select(e => new EquipmentItemViewModel
            {
                Id = e.Id,
                Brand = e.Brand,
                Name = e.Name,
                Type = e.Type,
                PricePerDay = e.PricePerDay,
                ImageUrl = e.ImageUrl
            }).ToList();

            return View(viewModels);
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);

            if (equipment == null)
                return NotFound();

            var viewModel = new EquipmentDetailViewModel
            {
                Id = equipment.Id,
                Brand = equipment.Brand,
                Name = equipment.Name,
                Type = equipment.Type,
                Year = equipment.Year,
                Description = equipment.Description,
                PricePerDay = equipment.PricePerDay,
                ImageUrl = equipment.ImageUrl
            };

            return View(viewModel);
        }

        // GET: Equipments/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EquipmentTypeId"] = new SelectList(await _equipmentRepository.GetEquipmentTypesAsync(), "Id", "Id");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Name,Type,Year,Description,PricePerDay,ImageUrl,EquipmentTypeId")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                await _equipmentRepository.AddAsync(equipment);
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            return equipment == null ? NotFound() : View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Name,Type,Year,Description,PricePerDay,ImageUrl,EquipmentTypeId")] Equipment equipment)
        {
            if (id != equipment.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                await _equipmentRepository.UpdateAsync(equipment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentTypeId"] = new SelectList(await _equipmentRepository.GetEquipmentTypesAsync(), "Id", "Id", equipment.EquipmentTypeId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            return equipment == null ? NotFound() : View(equipment);
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
