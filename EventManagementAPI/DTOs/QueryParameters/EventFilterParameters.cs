namespace EventManagementAPI.DTOs.QueryParameters
{
    public class EventFilterParameters
    {
        // Filter criteria
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
        public string? Status { get; set; }

        // Pagination parameters
        public int Page { get; set; } = 1;             // Number of the page (default 1)
        public int PageSize { get; set; } = 10;       // Number of items per page (default 10)
    }
}
