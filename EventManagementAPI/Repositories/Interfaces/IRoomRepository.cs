using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task AddAsync(Room room);
        void Update(Room room);
        void Remove(Room room);
        Task SaveChangesAsync();
    }
}
