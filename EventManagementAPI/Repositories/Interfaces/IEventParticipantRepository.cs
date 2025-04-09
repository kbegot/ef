using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface IEventParticipantRepository
    {
        Task<EventParticipant?> GetRegistrationAsync(int eventId, int participantId);
        Task AddAsync(EventParticipant registration);
        void Remove(EventParticipant registration);
        Task SaveChangesAsync();
    }
}
