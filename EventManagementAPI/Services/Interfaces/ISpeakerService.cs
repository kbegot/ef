using EventManagementAPI.DTOs;

namespace EventManagementAPI.Services.Interfaces
{
    public interface ISpeakerService
    {
        Task<IEnumerable<SpeakerDTO>> GetAllSpeakersAsync();
        Task<SpeakerDTO?> GetSpeakerByIdAsync(int id);
        Task<SpeakerDTO> CreateSpeakerAsync(CreateSpeakerDTO dto);
        Task<bool> UpdateSpeakerAsync(int id, CreateSpeakerDTO dto);
        Task<bool> DeleteSpeakerAsync(int id);
    }
}
