using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;

namespace EventManagementAPI.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _repository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RatingDTO>> GetAllRatingsAsync()
        {
            var ratings = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RatingDTO>>(ratings);
        }

        public async Task<RatingDTO?> GetRatingByIdAsync(int id)
        {
            var rating = await _repository.GetByIdAsync(id);
            return rating != null ? _mapper.Map<RatingDTO>(rating) : null;
        }

        public async Task<RatingDTO> CreateRatingAsync(CreateRatingDTO dto)
        {
            var rating = _mapper.Map<Rating>(dto);
            await _repository.AddAsync(rating);
            await _repository.SaveChangesAsync();
            return _mapper.Map<RatingDTO>(rating);
        }

        public async Task<bool> UpdateRatingAsync(int id, CreateRatingDTO dto)
        {
            var rating = await _repository.GetByIdAsync(id);
            if (rating == null) return false;
            _mapper.Map(dto, rating);
            _repository.Update(rating);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRatingAsync(int id)
        {
            var rating = await _repository.GetByIdAsync(id);
            if (rating == null) return false;
            _repository.Remove(rating);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
