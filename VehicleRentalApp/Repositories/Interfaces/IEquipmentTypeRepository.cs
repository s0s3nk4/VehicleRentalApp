using VehicleRentalApp.Models;

namespace VehicleRentalApp.Repositories.Interfaces
{
    public interface IEquipmentTypeRepository
    {
        Task<IEnumerable<EquipmentType>> GetAllAsync();
        Task<EquipmentType?> GetByIdAsync(int id);
        Task AddAsync(EquipmentType equipmentType);
        Task UpdateAsync(EquipmentType equipmentType);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
    }
}
