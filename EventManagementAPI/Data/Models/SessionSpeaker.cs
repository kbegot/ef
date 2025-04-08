namespace EventManagementAPI.Data.Models
{
    public class SessionSpeaker
    {
        public int SessionId { get; set; }
        public int SpeakerId { get; set; }
        public required string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? AttendanceDate { get; set; }

        public required Session Session { get; set; }
        public required Speaker Speaker { get; set; }
    }

}