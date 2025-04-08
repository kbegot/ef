namespace EventManagementAPI.DTOs
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Company { get; set; } = default!;
        public string JobTitle { get; set; } = default!;
    }

    public class CreateParticipantDTO
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Company { get; set; } = default!;
        public string JobTitle { get; set; } = default!;
    }
}
