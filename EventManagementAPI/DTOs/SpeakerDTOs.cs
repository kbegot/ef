namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Représente un intervenant pour la lecture des données.
    /// </summary>
    public class SpeakerDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de l'intervenant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le prénom de l'intervenant.
        /// </summary>
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le nom de famille de l'intervenant.
        /// </summary>
        public string LastName { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la biographie de l'intervenant.
        /// </summary>
        public string Bio { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit l'adresse e-mail de l'intervenant.
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le nom de l'entreprise de l'intervenant.
        /// </summary>
        public string Company { get; set; } = default!;
    }

    /// <summary>
    /// Contient les informations nécessaires pour créer un nouvel intervenant.
    /// </summary>
    public class CreateSpeakerDTO
    {
        /// <summary>
        /// Obtient ou définit le prénom de l'intervenant.
        /// </summary>
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le nom de famille de l'intervenant.
        /// </summary>
        public string LastName { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la biographie de l'intervenant.
        /// </summary>
        public string Bio { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit l'adresse e-mail de l'intervenant.
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le nom de l'entreprise de l'intervenant.
        /// </summary>
        public string Company { get; set; } = default!;
    }
}
