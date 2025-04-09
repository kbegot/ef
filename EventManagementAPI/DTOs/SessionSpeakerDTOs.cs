namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Représente l'association entre une session et un intervenant pour la lecture des données.
    /// </summary>
    public class SessionSpeakerDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant de la session.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'intervenant.
        /// </summary>
        public int SpeakerId { get; set; }

        /// <summary>
        /// Obtient ou définit le rôle de l'intervenant dans la session.
        /// </summary>
        public string Role { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la date d'enregistrement de l'association.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Obtient ou définit la date d'assistance, si applicable.
        /// </summary>
        public DateTime? AttendanceDate { get; set; }
    }

    /// <summary>
    /// Contient les données nécessaires pour créer une nouvelle association entre une session et un intervenant.
    /// </summary>
    public class CreateSessionSpeakerDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant de la session.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'intervenant.
        /// </summary>
        public int SpeakerId { get; set; }

        /// <summary>
        /// Obtient ou définit le rôle de l'intervenant dans la session.
        /// </summary>
        public string Role { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la date d'enregistrement de l'association.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Obtient ou définit la date d'assistance, si applicable.
        /// </summary>
        public DateTime? AttendanceDate { get; set; }
    }
}
