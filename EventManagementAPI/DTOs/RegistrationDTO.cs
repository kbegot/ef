namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Contient les informations nécessaires pour inscrire ou désinscrire un participant à un événement.
    /// </summary>
    public class RegistrationDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant de l'événement.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant du participant.
        /// </summary>
        public int ParticipantId { get; set; }
    }
}
