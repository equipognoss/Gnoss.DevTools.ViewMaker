namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo para el panel de repetición de subir recurso.
    /// </summary>
    [Serializable]
    public partial class UploadResourceReplayPanelModel
    {
        /// <summary>
        /// Indica si se puede repetir el recurso.
        /// </summary>
        public bool CanRepeatResource { get; set; }

        /// <summary>
        /// Url del recurso repetido, en caso de que esté repetido.
        /// </summary>
        public string RepeatedResourceUrl { get; set; }

        /// <summary>
        /// Url del recurso repetido.
        /// </summary>
        public string RepeatedResourceName { get; set; }

        /// <summary>
        /// Tipo de recurso repetido: 0 (ReferenciaADoc), 1(Hipervinculo), 2(Archivo), 3 (Generico para todos los tipos al editar), 4 (Aviso cambio de privacidad recurso), 5 (Aviso cambio de privacidad en debate), 6 (Cocurrencia).
        /// </summary>
        public int RepeatedResourceType { get; set; }

        /// <summary>
        /// Enlace repetido.
        /// </summary>
        public string RepetitionLink { get; set; }

        /// <summary>
        /// Información extra para el archivo.
        /// </summary>
        public string ExtraFile { get; set; }

        /// <summary>
        /// Nombre del perfil que causa la concurrencia.
        /// </summary>
        public string ProfileConcurrencyName { get; set; }

        /// <summary>
        /// Indica si se debe crear versión o no en caso de que haya concurrencia.
        /// </summary>
        public bool CreateVersionIfConcurrency { get; set; }

        /// <summary>
        /// Indica que es la página de añadir a GNOSS.
        /// </summary>
        public bool AddToGnossPage { get; set; }
    }
}
