using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Rating>> GetAllAsync();
        Task<Rating?> GetByIdAsync(int id);
        Task AddAsync(Rating rating);
        void Update(Rating rating);
        void Remove(Rating rating);
        Task SaveChangesAsync();
    }
}
