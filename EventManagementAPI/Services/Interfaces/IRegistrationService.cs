using EventManagementAPI.DTOs;

namespace EventManagementAPI.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<bool> RegisterAsync(RegistrationDTO dto);
        Task<bool> UnregisterAsync(int eventId, int participantId);
    }
}
