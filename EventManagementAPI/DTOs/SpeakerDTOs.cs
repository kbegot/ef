namespace EventManagementAPI.DTOs
{
    public class SpeakerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Bio { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Company { get; set; } = default!;
    }

    public class CreateSpeakerDTO
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Bio { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Company { get; set; } = default!;
    }
}
