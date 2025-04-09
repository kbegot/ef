namespace EventManagementAPI.DTOs
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int ParticipantId { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; } = default!;
    }

    public class CreateRatingDTO
    {
        public int SessionId { get; set; }
        public int ParticipantId { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; } = default!;
    }
}
