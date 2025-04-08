using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface ISpeakerRepository
    {
        Task<IEnumerable<Speaker>> GetAllAsync();
        Task<Speaker?> GetByIdAsync(int id);
        Task AddAsync(Speaker speaker);
        void Update(Speaker speaker);
        void Remove(Speaker speaker);
        Task SaveChangesAsync();
    }
}
