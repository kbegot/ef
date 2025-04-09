using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;

namespace EventManagementAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocationDTO>> GetAllLocationsAsync()
        {
            var locations = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<LocationDTO>>(locations);
        }

        public async Task<LocationDTO?> GetLocationByIdAsync(int id)
        {
            var location = await _repository.GetByIdAsync(id);
            return location == null ? null : _mapper.Map<LocationDTO>(location);
        }

        public async Task<LocationDTO> CreateLocationAsync(CreateLocationDTO dto)
        {
            var location = _mapper.Map<Location>(dto);
            await _repository.AddAsync(location);
            await _repository.SaveChangesAsync();
            return _mapper.Map<LocationDTO>(location);
        }

        public async Task<bool> UpdateLocationAsync(int id, CreateLocationDTO dto)
        {
            var location = await _repository.GetByIdAsync(id);
            if (location == null) return false;
            _mapper.Map(dto, location);
            _repository.Update(location);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = await _repository.GetByIdAsync(id);
            if (location == null) return false;
            _repository.Remove(location);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
