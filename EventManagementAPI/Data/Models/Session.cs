namespace EventManagementAPI.Data.Models
{
    public class Session
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EventId { get; set; }
        public int RoomId { get; set; }
        public required Event Event { get; set; }
        public required Room Room { get; set; }
        public required ICollection<SessionSpeaker> SessionSpeakers { get; set; }
        public required ICollection<Rating> Ratings { get; set; }
    }

}