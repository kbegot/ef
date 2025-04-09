namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Représente une notation attribuée par un participant à une session.
    /// </summary>
    public class RatingDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de la notation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de la session notée.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant du participant ayant attribué la notation.
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Obtient ou définit le score attribué à la session.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Obtient ou définit les commentaires associés à la notation.
        /// </summary>
        public string Comments { get; set; } = default!;
    }

    /// <summary>
    /// Contient les données requises pour créer une nouvelle notation.
    /// </summary>
    public class CreateRatingDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant de la session à noter.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant du participant qui attribue la notation.
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Obtient ou définit le score attribué à la session.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Obtient ou définit les commentaires accompagnant la notation.
        /// </summary>
        public string Comments { get; set; } = default!;
    }
}
