using VehicleRentalApp.Models;

namespace VehicleRentalApp.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<IEnumerable<EquipmentType>> GetEquipmentTypesAsync();
        Task<IEnumerable<RentalPoint>> GetRentalPointsAsync();
        Task<Equipment?> GetByIdAsync(int id);
        Task AddAsync(Equipment equipment);
        Task UpdateAsync(Equipment equipment);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
    }
}
