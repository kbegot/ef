using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(int id);
        Task AddAsync(Event ev);
        void Update(Event ev);
        void Remove(Event ev);
        Task SaveChangesAsync();
        IQueryable<Event> GetQueryable();
    }
}
