using Microsoft.AspNetCore.Mvc;
using VehicleRentalApp.Repositories.Interfaces;

namespace VehicleRentalApp.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var equipments = await _equipmentRepository.GetAllAsync();
            return View(equipments);
        }
    }
}
