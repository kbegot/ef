namespace EventManagementAPI.Data.Models
{
    public class EventParticipant
    {
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public Participant? Participant { get; set; }
        public Event? Event { get; set; }
    }
}