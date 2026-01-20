namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Enumeración para distinguir los tipos de actividad reciente
    /// </summary>
    public enum TipoActividadReciente
    {
        /// <summary>
        /// Actividad reciente de la home del usuario conectado
        /// </summary>
        HomeUsuario = 0,
        /// <summary>
        /// Actividad reciente de la home de un proyecto
        /// </summary>
        HomeProyecto = 1,
        /// <summary>
        /// Actividad reciente del perfil de persona en un proyecto
        /// </summary>
        PerfilProyecto = 2,
        /// <summary>
        /// Actividad reciente a la que estás suscrito en un proyecto
        /// </summary>
        SuscripcionProyecto = 3,
        /// <summary>
        /// Actividad reciente a la que estás suscrito en un proyecto
        /// </summary>
        Suscripcion = 4,
        /// <summary>
        /// Actividad reciente a la que estás suscrito en un proyecto, si no tienes, mostramos la home del proyecto
        /// </summary>
        SuscripcionSiNoHomeProyecto = 5,
    }
}
