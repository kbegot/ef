namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Représente une session d'un événement (données de lecture).
    /// </summary>
    public class SessionDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de la session.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le titre de la session.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la description de la session.
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la date et l'heure de début de la session.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Obtient ou définit la date et l'heure de fin de la session.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'événement auquel la session appartient.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de la salle dans laquelle se déroule la session.
        /// </summary>
        public int RoomId { get; set; }
    }

    /// <summary>
    /// Contient les données nécessaires pour créer une nouvelle session.
    /// </summary>
    public class CreateSessionDTO
    {
        /// <summary>
        /// Obtient ou définit le titre de la session.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la description de la session.
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la date et l'heure de début de la session.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Obtient ou définit la date et l'heure de fin de la session.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'événement auquel la session sera associée.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de la salle dans laquelle la session se déroulera.
        /// </summary>
        public int RoomId { get; set; }
    }
}
