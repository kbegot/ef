using EventManagementAPI.DTOs;

namespace EventManagementAPI.Services.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionDTO>> GetAllSessionsAsync();
        Task<SessionDTO?> GetSessionByIdAsync(int id);
        Task<SessionDTO> CreateSessionAsync(CreateSessionDTO dto);
        Task<bool> UpdateSessionAsync(int id, CreateSessionDTO dto);
        Task<bool> DeleteSessionAsync(int id);
    }
}
