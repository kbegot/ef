namespace EventManagementAPI.Data.Models
{
    public class Event
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required string Status { get; set; }
        public required string Category { get; set; }
 
        public required Location Location { get; set; }

        public required ICollection<Session> Sessions { get; set; }
        public int LocationId { get; set; }
        public required ICollection<EventParticipant> EventParticipants { get; set; }

    }

}