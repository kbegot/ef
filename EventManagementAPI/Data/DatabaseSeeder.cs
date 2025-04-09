using EventManagementAPI.Data.Models;

namespace EventManagementAPI.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Si les Locations existent déjà, on considère la base peuplée
            if (context.Locations.Any())
                return;

            // -------------------------
            // 1. Seed des Locations
            // -------------------------
            var locations = new List<Location>
            {
                new Location
                {
                    // Id non défini, la base le générera automatiquement
                    Name = "Centre de Conférence",
                    Address = "123 Rue A",
                    City = "Paris",
                    Country = "France",
                    Capacity = "500",
                    // Initialisation des collections requises
                    Events = new List<Event>(),
                    Rooms = new List<Room>()
                },
                new Location
                {
                    Name = "Hôtel de Ville",
                    Address = "456 Rue B",
                    City = "Lyon",
                    Country = "France",
                    Capacity = "300",
                    Events = new List<Event>(),
                    Rooms = new List<Room>()
                }
            };

            context.Locations.AddRange(locations);
            context.SaveChanges();

            // -------------------------
            // 2. Seed des Rooms
            // -------------------------
            var rooms = new List<Room>
            {
                new Room
                {
                    Name = "Salle A",
                    Capacity = 100,
                    LocationId = locations.First().Id, // La première location
                    Location = locations.First(),
                    Sessions = new List<Session>()
                },
                new Room
                {
                    Name = "Salle B",
                    Capacity = 200,
                    LocationId = locations.First().Id,
                    Location = locations.First(),
                    Sessions = new List<Session>()
                },
                new Room
                {
                    Name = "Salle C",
                    Capacity = 150,
                    LocationId = locations.Last().Id, // La deuxième location
                    Location = locations.Last(),
                    Sessions = new List<Session>()
                }
            };

            context.Rooms.AddRange(rooms);
            context.SaveChanges();

            // -------------------------
            // 3. Seed des Participants
            // -------------------------
            var participants = new List<Participant>
            {
                new Participant
                {
                    FirstName = "Alice",
                    LastName = "Dupont",
                    Email = "alice@example.com",
                    Company = "Company A",
                    JobTitle = "Manager",
                    EventParticipants = new List<EventParticipant>(),
                    Ratings = new List<Rating>()
                },
                new Participant
                {
                    FirstName = "Bob",
                    LastName = "Martin",
                    Email = "bob@example.com",
                    Company = "Company B",
                    JobTitle = "Developer",
                    EventParticipants = new List<EventParticipant>(),
                    Ratings = new List<Rating>()
                }
            };

            context.Participants.AddRange(participants);
            context.SaveChanges();

            // -------------------------
            // 4. Seed des Speakers
            // -------------------------
            var speakers = new List<Speaker>
            {
                new Speaker
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Bio = "Expert en technologie",
                    Email = "john@example.com",
                    Company = "Tech Corp",
                    SessionSpeakers = new List<SessionSpeaker>()
                },
                new Speaker
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Bio = "Experte en design",
                    Email = "jane@example.com",
                    Company = "Design Inc",
                    SessionSpeakers = new List<SessionSpeaker>()
                }
            };

            context.Speakers.AddRange(speakers);
            context.SaveChanges();

            // -------------------------
            // 5. Seed des Events
            // -------------------------
            var events = new List<Event>
            {
                new Event 
                {
                    Title = "Conférence Tech",
                    Description = "Conférence sur les technologies de pointe",
                    StartDate = DateTime.UtcNow.AddDays(10),
                    EndDate = DateTime.UtcNow.AddDays(11),
                    Status = "Programmé",
                    Category = "Technologie",
                    LocationId = locations.First().Id,
                    Location = locations.First(),
                    Sessions = new List<Session>(),
                    EventParticipants = new List<EventParticipant>()
                },
                new Event
                {
                    Title = "Atelier Design",
                    Description = "Atelier sur le design moderne",
                    StartDate = DateTime.UtcNow.AddDays(20),
                    EndDate = DateTime.UtcNow.AddDays(21),
                    Status = "Programmé",
                    Category = "Design",
                    LocationId = locations.Last().Id,
                    Location = locations.Last(),
                    Sessions = new List<Session>(),
                    EventParticipants = new List<EventParticipant>()
                }
            };

            context.Events.AddRange(events);
            context.SaveChanges();

            // -------------------------
            // 6. Seed des Sessions
            // -------------------------
            var sessions = new List<Session>
            {
                new Session
                {
                    Title = "Introduction à l'IA",
                    Description = "Les bases de l'intelligence artificielle",
                    StartDate = DateTime.UtcNow.AddDays(10).AddHours(1),
                    EndDate = DateTime.UtcNow.AddDays(10).AddHours(2),
                    EventId = events.First().Id,
                    RoomId = rooms.First().Id,
                    Event = events.First(),
                    Room = rooms.First(),
                    SessionSpeakers = new List<SessionSpeaker>(),
                    Ratings = new List<Rating>()
                },
                new Session
                {
                    Title = "Design Thinking",
                    Description = "Processus de design thinking",
                    StartDate = DateTime.UtcNow.AddDays(20).AddHours(1),
                    EndDate = DateTime.UtcNow.AddDays(20).AddHours(3),
                    EventId = events.Last().Id,
                    RoomId = rooms.Last().Id,
                    Event = events.Last(),
                    Room = rooms.Last(),
                    SessionSpeakers = new List<SessionSpeaker>(),
                    Ratings = new List<Rating>()
                }
            };

            context.Sessions.AddRange(sessions);
            context.SaveChanges();

            // -------------------------
            // 7. Seed des EventParticipants (Inscriptions)
            // -------------------------
            var eventParticipants = new List<EventParticipant>
            {
                new EventParticipant 
                {
                    EventId = events.First().Id, 
                    ParticipantId = participants.First().Id, 
                    RegistrationDate = DateTime.UtcNow,
                    Event = events.First(),
                    Participant = participants.First()
                },
                new EventParticipant 
                {
                    EventId = events.First().Id, 
                    ParticipantId = participants.Last().Id, 
                    RegistrationDate = DateTime.UtcNow,
                    Event = events.First(),
                    Participant = participants.Last()
                }
            };

            context.EventParticipants.AddRange(eventParticipants);
            context.SaveChanges();

            // -------------------------
            // 8. Seed des Ratings
            // -------------------------
            var ratings = new List<Rating>
            {
                new Rating 
                { 
                    Score = 5, 
                    Comments = "Session excellente !",
                    SessionId = sessions.First().Id,
                    ParticipantId = participants.First().Id,
                    Session = sessions.First(),
                    Participant = participants.First()
                },
                new Rating 
                { 
                    Score = 4, 
                    Comments = "Très intéressant.",
                    SessionId = sessions.Last().Id,
                    ParticipantId = participants.Last().Id,
                    Session = sessions.Last(),
                    Participant = participants.Last()
                }
            };

            context.Ratings.AddRange(ratings);
            context.SaveChanges();

            // -------------------------
            // 9. Seed des SessionSpeakers
            // -------------------------
            var sessionSpeakers = new List<SessionSpeaker>
            {
                new SessionSpeaker 
                {
                    SessionId = sessions.First().Id, 
                    SpeakerId = speakers.First().Id, 
                    Role = "Intervenant", 
                    RegistrationDate = DateTime.UtcNow,
                    Session = sessions.First(),
                    Speaker = speakers.First()
                },
                new SessionSpeaker 
                {
                    SessionId = sessions.Last().Id, 
                    SpeakerId = speakers.Last().Id, 
                    Role = "Intervenant", 
                    RegistrationDate = DateTime.UtcNow,
                    Session = sessions.Last(),
                    Speaker = speakers.Last()
                }
            };

            context.SessionSpeakers.AddRange(sessionSpeakers);
            context.SaveChanges();
        }
    }
}
