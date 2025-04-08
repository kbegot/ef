using EventManagementAPI.Data;
using EventManagementAPI.Data.Models;
using EventManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Repositories
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly AppDbContext _context;
        public SpeakerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Speaker>> GetAllAsync()
        {
            return await _context.Speakers.ToListAsync();
        }

        public async Task<Speaker?> GetByIdAsync(int id)
        {
            return await _context.Speakers.FindAsync(id);
        }

        public async Task AddAsync(Speaker speaker)
        {
            await _context.Speakers.AddAsync(speaker);
        }

        public void Update(Speaker speaker)
        {
            _context.Speakers.Update(speaker);
        }

        public void Remove(Speaker speaker)
        {
            _context.Speakers.Remove(speaker);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
