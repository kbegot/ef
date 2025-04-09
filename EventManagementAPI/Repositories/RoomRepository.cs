using EventManagementAPI.Data;
using EventManagementAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using EventManagementAPI.Repositories.Interfaces;

namespace EventManagementAPI.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;
        public RoomRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Room>> GetAllAsync() =>
            await _context.Rooms.ToListAsync();

        public async Task<Room?> GetByIdAsync(int id) =>
            await _context.Rooms.FindAsync(id);

        public async Task AddAsync(Room room) =>
            await _context.Rooms.AddAsync(room);

        public void Update(Room room) =>
            _context.Rooms.Update(room);

        public void Remove(Room room) =>
            _context.Rooms.Remove(room);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
