namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Représente une location, utilisée pour afficher les informations sur un lieu d’événement.
    /// </summary>
    public class LocationDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de la location.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de la location.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit l'adresse de la location.
        /// </summary>
        public string Address { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la ville où se situe la location.
        /// </summary>
        public string City { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le pays de la location.
        /// </summary>
        public string Country { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la capacité de la location (ex. "500").
        /// </summary>
        public string Capacity { get; set; } = default!;
    }

    /// <summary>
    /// Contient les données nécessaires pour créer une nouvelle location.
    /// </summary>
    public class CreateLocationDTO
    {
        /// <summary>
        /// Obtient ou définit le nom de la nouvelle location.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit l'adresse de la nouvelle location.
        /// </summary>
        public string Address { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la ville de la nouvelle location.
        /// </summary>
        public string City { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit le pays de la nouvelle location.
        /// </summary>
        public string Country { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la capacité de la nouvelle location.
        /// </summary>
        public string Capacity { get; set; } = default!;
    }
}
