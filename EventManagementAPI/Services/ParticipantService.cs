using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Repositories;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;

namespace EventManagementAPI.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _repository;
        private readonly IMapper _mapper;

        public ParticipantService(IParticipantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync()
        {
            var participants = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ParticipantDTO>>(participants);
        }

        public async Task<ParticipantDTO?> GetParticipantByIdAsync(int id)
        {
            var participant = await _repository.GetByIdAsync(id);
            return participant != null ? _mapper.Map<ParticipantDTO>(participant) : null;
        }

        public async Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto)
        {
            var participant = _mapper.Map<Participant>(dto);
            await _repository.AddAsync(participant);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ParticipantDTO>(participant);
        }

        public async Task<bool> UpdateParticipantAsync(int id, CreateParticipantDTO dto)
        {
            var participant = await _repository.GetByIdAsync(id);
            if (participant == null)
                return false;
            
            _mapper.Map(dto, participant);
            _repository.Update(participant);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteParticipantAsync(int id)
        {
            var participant = await _repository.GetByIdAsync(id);
            if (participant == null)
                return false;

            _repository.Remove(participant);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
