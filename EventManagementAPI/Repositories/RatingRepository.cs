using EventManagementAPI.Data;
using EventManagementAPI.Data.Models;
using EventManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;
        public RatingRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Rating>> GetAllAsync() =>
            await _context.Ratings.Include(r => r.Session).Include(r => r.Participant).ToListAsync();

        public async Task<Rating?> GetByIdAsync(int id) =>
            await _context.Ratings.Include(r => r.Session).Include(r => r.Participant).FirstOrDefaultAsync(r => r.Id == id);

        public async Task AddAsync(Rating rating) =>
            await _context.Ratings.AddAsync(rating);

        public void Update(Rating rating) =>
            _context.Ratings.Update(rating);

        public void Remove(Rating rating) =>
            _context.Ratings.Remove(rating);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
