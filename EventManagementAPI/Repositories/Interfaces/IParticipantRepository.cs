using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> GetAllAsync();
        Task<Participant?> GetByIdAsync(int id);
        Task AddAsync(Participant participant);
        void Update(Participant participant);
        void Remove(Participant participant);
        Task SaveChangesAsync();
    }
}
