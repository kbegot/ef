using EventManagementAPI.DTOs;

namespace EventManagementAPI.Services.Interfaces
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingDTO>> GetAllRatingsAsync();
        Task<RatingDTO?> GetRatingByIdAsync(int id);
        Task<RatingDTO> CreateRatingAsync(CreateRatingDTO dto);
        Task<bool> UpdateRatingAsync(int id, CreateRatingDTO dto);
        Task<bool> DeleteRatingAsync(int id);
    }
}
