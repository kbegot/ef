using EventManagementAPI.Data;
using EventManagementAPI.Data.Models;
using EventManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            // Inclut la relation avec le Location si nécessaire
            return await _context.Events.Include(e => e.Location).ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            return await _context.Events.Include(e => e.Location)
                                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Event ev)
        {
            await _context.Events.AddAsync(ev);
        }

        public void Update(Event ev)
        {
            _context.Events.Update(ev);
        }

        public void Remove(Event ev)
        {
            _context.Events.Remove(ev);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
