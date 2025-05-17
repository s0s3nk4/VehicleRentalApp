using Microsoft.EntityFrameworkCore;
using VehicleRentalApp.Data;
using VehicleRentalApp.Models;
using VehicleRentalApp.Repositories.Interfaces;

namespace VehicleRentalApp.Repositories
{
    public class EquipmentTypeRepository : IEquipmentTypeRepository
    {
        private readonly AppDbContext _context;
        public EquipmentTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EquipmentType>> GetAllAsync()
        {
            return await _context.EquipmentTypes.ToListAsync();
        }
        public async Task<EquipmentType?> GetByIdAsync(int id)
        {
            return await _context.EquipmentTypes.FindAsync(id);
        }
        public async Task AddAsync(EquipmentType equipmentType)
        {
            _context.EquipmentTypes.Add(equipmentType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(EquipmentType equipmentType)
        {
            _context.EquipmentTypes.Update(equipmentType);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var equipmentType = await GetByIdAsync(id);
            if (equipmentType != null)
            {
                _context.EquipmentTypes.Remove(equipmentType);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await _context.EquipmentTypes.AnyAsync(e => e.Id == id);
        }
    }
}
