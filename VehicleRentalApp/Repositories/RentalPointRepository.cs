using Microsoft.EntityFrameworkCore;
using VehicleRentalApp.Data;
using VehicleRentalApp.Models;
using VehicleRentalApp.Repositories.Interfaces;

namespace VehicleRentalApp.Repositories
{
    public class RentalPointRepository : IRentalPointRepository
    {
        private readonly AppDbContext _context;
        public RentalPointRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RentalPoint>> GetAllAsync()
        {
            return await _context.RentalPoints.ToListAsync();
        }
        public async Task<RentalPoint?> GetByIdAsync(int id)
        {
            return await _context.RentalPoints.FindAsync(id);
        }
        public async Task AddAsync(RentalPoint rentalPoint)
        {
            await _context.RentalPoints.AddAsync(rentalPoint);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(RentalPoint rentalPoint)
        {
            _context.RentalPoints.Update(rentalPoint);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var rentalPoint = await GetByIdAsync(id);
            if (rentalPoint != null)
            {
                _context.RentalPoints.Remove(rentalPoint);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.RentalPoints.AnyAsync(e => e.Id == id);
        }
    }
}
