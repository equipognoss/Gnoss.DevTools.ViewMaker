namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Visibilidad de un recurso en una comunidad.
    /// </summary>
    public enum ResourceVisibility
    {
        /// <summary>
        /// Abierto, todo el mundo podrá verlo, incluso los que no sean miembros de la comunidad.
        /// </summary>
        Open = 0,
        /// <summary>
        /// Miembros comunidad, solo los miembros de la comunidad podrán ver el recurso.
        /// </summary>
        CommunityMembers = 1,
        /// <summary>
        /// Solo editores, únicamente los editores del recurso tendrán acceso al mismo.
        /// </summary>
        OnlyEditors = 2,
        /// <summary>
        /// Lectores específicos, solo podrán ver el recurso un conjunto de lectores especificados y los editores.
        /// </summary>
        SpecificReaders = 3
    }
}
