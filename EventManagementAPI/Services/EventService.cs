using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Repositories;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;

namespace EventManagementAPI.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync()
        {
            var events = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EventDTO>>(events);
        }

        public async Task<EventDTO?> GetEventByIdAsync(int id)
        {
            var ev = await _repository.GetByIdAsync(id);
            return ev != null ? _mapper.Map<EventDTO>(ev) : null;
        }

        public async Task<EventDTO> CreateEventAsync(CreateEventDTO createEventDto)
        {
            var ev = _mapper.Map<Event>(createEventDto);
            await _repository.AddAsync(ev);
            await _repository.SaveChangesAsync();
            return _mapper.Map<EventDTO>(ev);
        }

        public async Task<bool> UpdateEventAsync(int id, CreateEventDTO updateDto)
        {
            var ev = await _repository.GetByIdAsync(id);
            if (ev == null)
            {
                return false;
            }
            // Appliquer le mapping pour mettre à jour l’entité
            _mapper.Map(updateDto, ev);
            _repository.Update(ev);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var ev = await _repository.GetByIdAsync(id);
            if (ev == null)
            {
                return false;
            }
            _repository.Remove(ev);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
