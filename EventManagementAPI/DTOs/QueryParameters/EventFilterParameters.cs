namespace EventManagementAPI.DTOs.QueryParameters
{
    public class EventFilterParameters
    {
        // Paramètres de filtrage
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
        public string? Status { get; set; }

        // Pagination
        public int Page { get; set; } = 1;             // Numéro de la page (défaut 1)
        public int PageSize { get; set; } = 10;       // Nombre d'éléments par page (défaut 10)
    }
}
