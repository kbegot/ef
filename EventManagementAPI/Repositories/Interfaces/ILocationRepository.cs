using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location?> GetByIdAsync(int id);
        Task AddAsync(Location location);
        void Update(Location location);
        void Remove(Location location);
        Task SaveChangesAsync();
    }
}
