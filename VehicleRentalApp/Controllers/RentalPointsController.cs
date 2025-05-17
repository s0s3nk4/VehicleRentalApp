using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VehicleRentalApp.Data;
using VehicleRentalApp.Models;
using VehicleRentalApp.Repositories;
using VehicleRentalApp.Repositories.Interfaces;
using VehicleRentalApp.ViewModels;

namespace VehicleRentalApp.Controllers
{
    public class RentalPointsController : Controller
    {
        private readonly IRentalPointRepository _rentalPointRepository;
        private readonly IMapper _mapper;
        public RentalPointsController(IRentalPointRepository rentalPointRepository, IMapper mapper)
        {
            _rentalPointRepository = rentalPointRepository;
            _mapper = mapper;
        }

        // GET: RentalPoints
        public async Task<IActionResult> Index()
        {
            var points = await _rentalPointRepository.GetAllAsync();
            var viewModels = _mapper.Map<List<RentalPointViewModel>>(points);
            return View(viewModels);
        }

        // GET: RentalPoints/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var point = await _rentalPointRepository.GetByIdAsync(id);
            if (point == null)
                return NotFound();

            var viewModel = _mapper.Map<RentalPointViewModel>(point);
            return View(viewModel);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] RentalPointViewModel model)
        {
            if (ModelState.IsValid)
            {
                var point = _mapper.Map<RentalPoint>(model);
                await _rentalPointRepository.AddAsync(point);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: RentalPoints/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var point = await _rentalPointRepository.GetByIdAsync(id);
            if (point == null)
                return NotFound();

            var viewModel = _mapper.Map<RentalPointViewModel>(point);
            return View(viewModel);
        }

        // POST: RentalPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] RentalPointViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var point = _mapper.Map<RentalPoint>(model);
                await _rentalPointRepository.UpdateAsync(point);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: RentalPoints/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var point = await _rentalPointRepository.GetByIdAsync(id);
            if (point == null)
                return NotFound();

            var viewModel = _mapper.Map<RentalPointViewModel>(point);
            return View(viewModel);
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
