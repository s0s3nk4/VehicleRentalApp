using VehicleRentalApp.Models;

namespace VehicleRentalApp.Repositories.Interfaces
{
    public interface IRentalPointRepository
    {
        Task<IEnumerable<RentalPoint>> GetAllAsync();
        Task<RentalPoint?> GetByIdAsync(int id);
        Task AddAsync(RentalPoint rentalPoint);
        Task UpdateAsync(RentalPoint rentalPoint);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
