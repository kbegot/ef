using EventManagementAPI.Data;
using EventManagementAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using EventManagementAPI.Repositories.Interfaces;

namespace EventManagementAPI.Repositories
{
    public class EventParticipantRepository : IEventParticipantRepository
    {
        private readonly AppDbContext _context;
        public EventParticipantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EventParticipant?> GetRegistrationAsync(int eventId, int participantId) =>
            await _context.EventParticipants.FirstOrDefaultAsync(ep =>
                ep.EventId == eventId && ep.ParticipantId == participantId);

        public async Task AddAsync(EventParticipant registration) =>
            await _context.EventParticipants.AddAsync(registration);

        public void Remove(EventParticipant registration) =>
            _context.EventParticipants.Remove(registration);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
