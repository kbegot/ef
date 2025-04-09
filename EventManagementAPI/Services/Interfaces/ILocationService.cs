using EventManagementAPI.DTOs;

namespace EventManagementAPI.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetAllLocationsAsync();
        Task<LocationDTO?> GetLocationByIdAsync(int id);
        Task<LocationDTO> CreateLocationAsync(CreateLocationDTO dto);
        Task<bool> UpdateLocationAsync(int id, CreateLocationDTO dto);
        Task<bool> DeleteLocationAsync(int id);
    }
}
