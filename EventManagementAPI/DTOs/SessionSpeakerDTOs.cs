namespace EventManagementAPI.DTOs
{
    public class SessionSpeakerDTO
    {
        public int SessionId { get; set; }
        public int SpeakerId { get; set; }
        public string Role { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public DateTime? AttendanceDate { get; set; }
    }

    public class CreateSessionSpeakerDTO
    {
        public int SessionId { get; set; }
        public int SpeakerId { get; set; }
        public string Role { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public DateTime? AttendanceDate { get; set; }
    }
}
