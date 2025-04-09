namespace EventManagementAPI.DTOs
{
    /// <summary>
    /// Représente un résultat paginé générique pour l'API.
    /// </summary>
    /// <typeparam name="T">Le type des éléments contenus dans le résultat paginé.</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Obtient ou définit le numéro de la page actuelle.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre d'éléments par page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre total d'éléments disponibles.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Obtient ou définit la collection d'éléments pour la page actuelle.
        /// </summary>
        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}
