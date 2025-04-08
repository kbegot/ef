namespace EventManagementAPI.Data.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Company { get; set; }
        public required string JobTitle { get; set; }
        public required ICollection<EventParticipant> EventParticipants { get; set; }
        public required ICollection<Rating> Ratings { get; set; }
    }

}