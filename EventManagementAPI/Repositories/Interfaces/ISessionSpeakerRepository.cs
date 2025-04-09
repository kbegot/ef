using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface ISessionSpeakerRepository
    {
        Task<IEnumerable<SessionSpeaker>> GetAllAsync();
        Task<SessionSpeaker?> GetByIdAsync(int sessionId, int speakerId);
        Task AddAsync(SessionSpeaker sessionSpeaker);
        void Update(SessionSpeaker sessionSpeaker);
        void Remove(SessionSpeaker sessionSpeaker);
        Task SaveChangesAsync();
    }
}
