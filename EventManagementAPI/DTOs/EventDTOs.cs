namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Représente un événement dans l'API.
    /// </summary>
    public class EventDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de l'événement.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le titre de l'événement.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la description de l'événement.
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la date et l'heure de début de l'événement.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Obtient ou définit la date et l'heure de fin de l'événement.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Obtient ou définit le statut de l'événement (par exemple, "Programmé", "En cours", "Terminé").
        /// </summary>
        public string Status { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la catégorie de l'événement (par exemple, "Technologie", "Design").
        /// </summary>
        public string Category { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit l'identifiant de la location où se déroule l'événement.
        /// </summary>
        public int LocationId { get; set; }
    }

    /// <summary>
    /// Représente les données nécessaires pour créer un nouvel événement.
    /// </summary>
    public class CreateEventDTO
    {
        /// <summary>
        /// Obtient ou définit le titre de l'événement.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la description de l'événement.
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la date et l'heure de début de l'événement.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Obtient ou définit la date et l'heure de fin de l'événement.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Obtient ou définit le statut de l'événement.
        /// </summary>
        public string Status { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la catégorie de l'événement.
        /// </summary>
        public string Category { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit l'identifiant de la location où se tiendra l'événement.
        /// </summary>
        public int LocationId { get; set; }
    }
}
