using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VehicleRentalApp.Data;
using VehicleRentalApp.Models;
using VehicleRentalApp.Repositories.Interfaces;

namespace VehicleRentalApp.Controllers
{
    public class RentalPointsController : Controller
    {
        private readonly IRentalPointRepository _rentalPointRepository;
        public RentalPointsController(IRentalPointRepository rentalPointRepository)
        {
            _rentalPointRepository = rentalPointRepository;
        }

        // GET: RentalPoints
        public async Task<IActionResult> Index()
        {
            var points = await _rentalPointRepository.GetAllAsync();
            return View(points);
        }

        // GET: RentalPoints/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rentalPoint = await _rentalPointRepository.GetByIdAsync(id);
            if (rentalPoint == null) return NotFound();
            return View(rentalPoint);
        }

        // GET: RentalPoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] RentalPoint rentalPoint)
        {
            if (ModelState.IsValid)
            {
                await _rentalPointRepository.AddAsync(rentalPoint);
                return RedirectToAction(nameof(Index));
            }
            return View(rentalPoint);
        }

        // GET: RentalPoints/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rentalPoint = await _rentalPointRepository.GetByIdAsync(id);
            if (rentalPoint == null) return NotFound();
            return View(rentalPoint);
        }

        // POST: RentalPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] RentalPoint rentalPoint)
        {
            if (id != rentalPoint.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _rentalPointRepository.UpdateAsync(rentalPoint);
                return RedirectToAction(nameof(Index));
            }
            return View(rentalPoint);
        }

        // GET: RentalPoints/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var rentalPoint = await _rentalPointRepository.GetByIdAsync(id);
            if (rentalPoint == null) return NotFound();
            return View(rentalPoint);
        }

        // POST: RentalPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rentalPointRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RentalPointExists(int id)
        {
            return await _rentalPointRepository.ExistsAsync(id);
        }
    }
}
