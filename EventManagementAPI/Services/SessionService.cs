using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Repositories;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;

namespace EventManagementAPI.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _repository;
        private readonly IMapper _mapper;

        public SessionService(ISessionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SessionDTO>> GetAllSessionsAsync()
        {
            var sessions = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SessionDTO>>(sessions);
        }

        public async Task<SessionDTO?> GetSessionByIdAsync(int id)
        {
            var session = await _repository.GetByIdAsync(id);
            return session != null ? _mapper.Map<SessionDTO>(session) : null;
        }

        public async Task<SessionDTO> CreateSessionAsync(CreateSessionDTO dto)
        {
            var session = _mapper.Map<Session>(dto);
            await _repository.AddAsync(session);
            await _repository.SaveChangesAsync();
            return _mapper.Map<SessionDTO>(session);
        }

        public async Task<bool> UpdateSessionAsync(int id, CreateSessionDTO dto)
        {
            var session = await _repository.GetByIdAsync(id);
            if (session == null)
                return false;
            _mapper.Map(dto, session);
            _repository.Update(session);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSessionAsync(int id)
        {
            var session = await _repository.GetByIdAsync(id);
            if (session == null)
                return false;
            _repository.Remove(session);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
