namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Représente un participant pour la lecture des données.
    /// </summary>
    public class ParticipantDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du participant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le prénom du participant.
        /// </summary>
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le nom de famille du participant.
        /// </summary>
        public string LastName { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit l'adresse e-mail du participant.
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le nom de la compagnie associée au participant.
        /// </summary>
        public string Company { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le titre de poste du participant.
        /// </summary>
        public string JobTitle { get; set; } = default!;
    }

    /// <summary>
    /// Contient les données requises pour créer un nouveau participant.
    /// </summary>
    public class CreateParticipantDTO
    {
        /// <summary>
        /// Obtient ou définit le prénom du participant.
        /// </summary>
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le nom de famille du participant.
        /// </summary>
        public string LastName { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit l'adresse e-mail du participant.
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le nom de la compagnie associée au participant.
        /// </summary>
        public string Company { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le titre du poste du participant.
        /// </summary>
        public string JobTitle { get; set; } = default!;
    }
}
