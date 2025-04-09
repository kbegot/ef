using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.DTOs.QueryParameters;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        // Ajout de la méthode de filtrage et pagination
        public async Task<PagedResult<EventDTO>> GetFilteredEventsAsync(EventFilterParameters filterParams)
        {
            // On part de la queryable pour appliquer les filtres
            var query = _repository.GetQueryable();

            if (filterParams.StartDate.HasValue)
                query = query.Where(e => e.StartDate >= filterParams.StartDate.Value);

            if (filterParams.EndDate.HasValue)
                query = query.Where(e => e.EndDate <= filterParams.EndDate.Value);

            if (!string.IsNullOrEmpty(filterParams.Location))
                query = query.Where(e => e.Location.Name.Contains(filterParams.Location));

            if (!string.IsNullOrEmpty(filterParams.Category))
                query = query.Where(e => e.Category.Contains(filterParams.Category));

            if (!string.IsNullOrEmpty(filterParams.Status))
                query = query.Where(e => e.Status.Contains(filterParams.Status));

            int totalItems = await query.CountAsync();

            var eventsList = await query
                .Skip((filterParams.Page - 1) * filterParams.PageSize)
                .Take(filterParams.PageSize)
                .ToListAsync();

            var result = new PagedResult<EventDTO>
            {
                Page = filterParams.Page,
                PageSize = filterParams.PageSize,
                TotalItems = totalItems,
                Items = _mapper.Map<IEnumerable<EventDTO>>(eventsList)
            };

            return result;
        }
    }
}
