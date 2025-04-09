using EventManagementAPI.DTOs;

namespace EventManagementAPI.Services.Interfaces
{
    public interface ISessionSpeakerService
    {
        Task<IEnumerable<SessionSpeakerDTO>> GetAllSessionSpeakersAsync();
        Task<SessionSpeakerDTO?> GetSessionSpeakerAsync(int sessionId, int speakerId);
        Task<SessionSpeakerDTO> CreateSessionSpeakerAsync(CreateSessionSpeakerDTO dto);
        Task<bool> UpdateSessionSpeakerAsync(int sessionId, int speakerId, CreateSessionSpeakerDTO dto);
        Task<bool> DeleteSessionSpeakerAsync(int sessionId, int speakerId);
    }
}
