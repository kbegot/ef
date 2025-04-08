namespace EventManagementAPI.Data.Models
{
    public class EventParticipant
    {
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? AttendanceDate { get; set; } // Nullable if not yet attended
        public required Participant Participant { get; set; }

        public required Event Event { get; set; } // Navigation vers l'objet Event
    }
}