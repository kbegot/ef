using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;

namespace EventManagementAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRoomsAsync()
        {
            var rooms = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDTO>>(rooms);
        }

        public async Task<RoomDTO?> GetRoomByIdAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            return room == null ? null : _mapper.Map<RoomDTO>(room);
        }

        public async Task<RoomDTO> CreateRoomAsync(CreateRoomDTO dto)
        {
            var room = _mapper.Map<Room>(dto);
            await _repository.AddAsync(room);
            await _repository.SaveChangesAsync();
            return _mapper.Map<RoomDTO>(room);
        }

        public async Task<bool> UpdateRoomAsync(int id, CreateRoomDTO dto)
        {
            var room = await _repository.GetByIdAsync(id);
            if (room == null) return false;
            _mapper.Map(dto, room);
            _repository.Update(room);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            if (room == null) return false;
            _repository.Remove(room);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
