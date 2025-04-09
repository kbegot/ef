using EventManagementAPI.Data;
using EventManagementAPI.Data.Models;
using EventManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Repositories
{
    public class SessionSpeakerRepository : ISessionSpeakerRepository
    {
        private readonly AppDbContext _context;
        public SessionSpeakerRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<SessionSpeaker>> GetAllAsync() =>
            await _context.SessionSpeakers.Include(ss => ss.Session)
                                          .Include(ss => ss.Speaker)
                                          .ToListAsync();

        public async Task<SessionSpeaker?> GetByIdAsync(int sessionId, int speakerId) =>
            await _context.SessionSpeakers
                .Include(ss => ss.Session)
                .Include(ss => ss.Speaker)
                .FirstOrDefaultAsync(ss => ss.SessionId == sessionId && ss.SpeakerId == speakerId);

        public async Task AddAsync(SessionSpeaker sessionSpeaker) =>
            await _context.SessionSpeakers.AddAsync(sessionSpeaker);

        public void Update(SessionSpeaker sessionSpeaker) =>
            _context.SessionSpeakers.Update(sessionSpeaker);

        public void Remove(SessionSpeaker sessionSpeaker) =>
            _context.SessionSpeakers.Remove(sessionSpeaker);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
