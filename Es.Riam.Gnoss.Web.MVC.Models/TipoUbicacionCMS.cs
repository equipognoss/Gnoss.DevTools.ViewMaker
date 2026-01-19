namespace Es.Riam.Gnoss.AD.CMS
{
    /// <summary>
    /// Enumeración para distinguir tipos de Ubicaciones para el CMS
    /// </summary>
    public enum TipoUbicacionCMS
    {
        /// <summary>
        /// Home de la comunidad para un miembro de la comunidad
        /// </summary>
        HomeProyectoMiembro = 0,
        /// <summary>
        /// Home de la comunidad para alguien que no es miembro de la comunidad
        /// </summary>
        HomeProyectoNoMiembro = 1,
        /// <summary>
        /// Home de la comunidad para todo el mundo
        /// </summary>
        HomeProyecto = 2
    }
}
