namespace EventManagementAPI.Data.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int ParticipantId { get; set; }
        public int Score { get; set; }
        public required string Comments { get; set; }

        public required Session Session { get; set; }
        public required Participant Participant { get; set; }
    }

}