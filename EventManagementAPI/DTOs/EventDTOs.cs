namespace EventManagementAPI.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = default!;
        public string Category { get; set; } = default!;
        public int LocationId { get; set; }
    }

    public class CreateEventDTO
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = default!;
        public string Category { get; set; } = default!;
        public int LocationId { get; set; }
    }
}
