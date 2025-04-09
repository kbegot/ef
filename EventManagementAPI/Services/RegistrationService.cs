using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services.Interfaces;

namespace EventManagementAPI.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IEventParticipantRepository _repository;
        public RegistrationService(IEventParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> RegisterAsync(RegistrationDTO dto)
        {
            // Vérifier si le participant est déjà inscrit
            var existing = await _repository.GetRegistrationAsync(dto.EventId, dto.ParticipantId);
            if (existing != null) return false; // ou retourner true selon la logique désirée

            var registration = new EventParticipant
            {
                EventId = dto.EventId,
                ParticipantId = dto.ParticipantId,
                RegistrationDate = DateTime.UtcNow
            };

            await _repository.AddAsync(registration);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnregisterAsync(int eventId, int participantId)
        {
            var registration = await _repository.GetRegistrationAsync(eventId, participantId);
            if (registration == null) return false;

            _repository.Remove(registration);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
