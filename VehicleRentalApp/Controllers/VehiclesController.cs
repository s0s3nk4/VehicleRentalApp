using Microsoft.AspNetCore.Mvc;
using VehicleRentalApp.Models;
using VehicleRentalApp.ViewModels;

namespace VehicleRentalApp.Controllers
{
    public class VehiclesController : Controller
    {
        private static readonly List<Equipment> _vehicles = new()
        {
            new Equipment {
                Id = 1,
                Brand = "Toyota",
                Name = "Camry",
                Type = "Sedan",
                Year = 2020,
                Description = "Niezawodny i oszczędny sedan",
                PricePerDay = 50.00m,
                ImageUrl = "/images/camry.jpg"
            },
            new Equipment {
                Id = 2,
                Brand = "Ford",
                Name = "F-150",
                Type = "Truck",
                Year = 2021,
                Description = "Mocny i wszechstronny pickup",
                PricePerDay = 70.00m,
                ImageUrl = "/images/f150.jpg"
            },
            new Equipment {
                Id = 3,
                Brand = "Honda",
                Name = "Civic",
                Type = "Hatchback",
                Year = 2019,
                Description = "Stylowy i oszczędny hatchback",
                PricePerDay = 45.00m,
                ImageUrl = "/images/civic.jpg"
            },
        };
        public IActionResult Index()
        {
            var model = _vehicles.Select(v => new VehicleItemViewModel
            {
                Id = v.Id,
                Brand = v.Brand,
                Name = v.Name,
                Type = v.Type,
                PricePerDay = v.PricePerDay,
                ImageUrl = v.ImageUrl
            }).ToList();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
                return NotFound();

            var model = new VehicleDetailViewModel
            {
                Id = vehicle.Id,
                Brand = vehicle.Brand,
                Name = vehicle.Name,
                Type = vehicle.Type,
                Year = vehicle.Year,
                Description = vehicle.Description,
                PricePerDay = vehicle.PricePerDay,
                ImageUrl = vehicle.ImageUrl
            };
            return View(model);
        }
    }
}
