using EventManagementAPI.DTOs;
using EventManagementAPI.DTOs.QueryParameters;

namespace EventManagementAPI.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetAllEventsAsync();
        Task<EventDTO?> GetEventByIdAsync(int id);
        Task<EventDTO> CreateEventAsync(CreateEventDTO createEventDto);
        Task<bool> UpdateEventAsync(int id, CreateEventDTO updateDto);
        Task<bool> DeleteEventAsync(int id);
        Task<PagedResult<EventDTO>> GetFilteredEventsAsync(EventFilterParameters filterParams);
    }
}
