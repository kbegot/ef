namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Représente une salle pour la lecture des données.
    /// </summary>
    public class RoomDTO
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de la salle.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de la salle.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la capacité de la salle.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de la location associée à la salle.
        /// </summary>
        public int LocationId { get; set; }
    }

    /// <summary>
    /// Contient les informations nécessaires pour créer une nouvelle salle.
    /// </summary>
    public class CreateRoomDTO
    {
        /// <summary>
        /// Obtient ou définit le nom de la salle.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Obtient ou définit la capacité de la salle.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de la location associée.
        /// </summary>
        public int LocationId { get; set; }
    }
}
