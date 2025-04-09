using EventManagementAPI.DTOs;

namespace EventManagementAPI.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetAllRoomsAsync();
        Task<RoomDTO?> GetRoomByIdAsync(int id);
        Task<RoomDTO> CreateRoomAsync(CreateRoomDTO dto);
        Task<bool> UpdateRoomAsync(int id, CreateRoomDTO dto);
        Task<bool> DeleteRoomAsync(int id);
    }
}
