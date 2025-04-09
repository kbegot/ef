using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;

namespace EventManagementAPI.Services
{
    public class SessionSpeakerService : ISessionSpeakerService
    {
        private readonly ISessionSpeakerRepository _repository;
        private readonly IMapper _mapper;

        public SessionSpeakerService(ISessionSpeakerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SessionSpeakerDTO>> GetAllSessionSpeakersAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SessionSpeakerDTO>>(list);
        }

        public async Task<SessionSpeakerDTO?> GetSessionSpeakerAsync(int sessionId, int speakerId)
        {
            var entity = await _repository.GetByIdAsync(sessionId, speakerId);
            return entity != null ? _mapper.Map<SessionSpeakerDTO>(entity) : null;
        }

        public async Task<SessionSpeakerDTO> CreateSessionSpeakerAsync(CreateSessionSpeakerDTO dto)
        {
            var entity = _mapper.Map<SessionSpeaker>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<SessionSpeakerDTO>(entity);
        }

        public async Task<bool> UpdateSessionSpeakerAsync(int sessionId, int speakerId, CreateSessionSpeakerDTO dto)
        {
            var entity = await _repository.GetByIdAsync(sessionId, speakerId);
            if (entity == null)
                return false;
            _mapper.Map(dto, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSessionSpeakerAsync(int sessionId, int speakerId)
        {
            var entity = await _repository.GetByIdAsync(sessionId, speakerId);
            if (entity == null)
                return false;
            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
