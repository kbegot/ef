using EventManagementAPI.DTOs;

namespace EventManagementAPI.Services.Interfaces
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync();
        Task<ParticipantDTO?> GetParticipantByIdAsync(int id);
        Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto);
        Task<bool> UpdateParticipantAsync(int id, CreateParticipantDTO dto);
        Task<bool> DeleteParticipantAsync(int id);
    }
}
