using EventManagementAPI.Data;
using EventManagementAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using EventManagementAPI.Repositories.Interfaces;

namespace EventManagementAPI.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;
        public LocationRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Location>> GetAllAsync() =>
            await _context.Locations.ToListAsync();

        public async Task<Location?> GetByIdAsync(int id) =>
            await _context.Locations.FindAsync(id);

        public async Task AddAsync(Location location) =>
            await _context.Locations.AddAsync(location);

        public void Update(Location location) =>
            _context.Locations.Update(location);

        public void Remove(Location location) =>
            _context.Locations.Remove(location);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
