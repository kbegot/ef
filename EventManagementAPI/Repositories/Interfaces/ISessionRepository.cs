using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(int id);
        Task AddAsync(Session session);
        void Update(Session session);
        void Remove(Session session);
        Task SaveChangesAsync();
    }
}
