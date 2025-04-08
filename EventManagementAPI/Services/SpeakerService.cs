using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Repositories;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;

namespace EventManagementAPI.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _repository;
        private readonly IMapper _mapper;

        public SpeakerService(ISpeakerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpeakerDTO>> GetAllSpeakersAsync()
        {
            var speakers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SpeakerDTO>>(speakers);
        }

        public async Task<SpeakerDTO?> GetSpeakerByIdAsync(int id)
        {
            var speaker = await _repository.GetByIdAsync(id);
            return speaker != null ? _mapper.Map<SpeakerDTO>(speaker) : null;
        }

        public async Task<SpeakerDTO> CreateSpeakerAsync(CreateSpeakerDTO dto)
        {
            var speaker = _mapper.Map<Speaker>(dto);
            await _repository.AddAsync(speaker);
            await _repository.SaveChangesAsync();
            return _mapper.Map<SpeakerDTO>(speaker);
        }

        public async Task<bool> UpdateSpeakerAsync(int id, CreateSpeakerDTO dto)
        {
            var speaker = await _repository.GetByIdAsync(id);
            if (speaker == null)
                return false;
            _mapper.Map(dto, speaker);
            _repository.Update(speaker);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSpeakerAsync(int id)
        {
            var speaker = await _repository.GetByIdAsync(id);
            if (speaker == null)
                return false;
            _repository.Remove(speaker);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
