namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS de tipo Envío de correo
    /// </summary>
    public class CMSComponentMail : CMSComponent
    {
        /// <summary>
        /// Lista de campos del formulario
        /// </summary>
        public List<CMSFormFiled> FormFields { get; set; }

        /// <summary>
        /// Texto para el botón de envío de formulario
        /// </summary>
        public string TextButton { get; set; }

        /// <summary>
        /// Texto de notificación de envío correcto
        /// </summary>
        public string TextOK { get; set; }

        /// <summary>
        /// Url de envío de formulario
        /// </summary>
        public string UrlSendForm { get; set; }

        /// <summary>
        /// Representa un campo del formulario de envío de correo
        /// </summary>
        [Serializable]
        public class CMSFormFiled
        {
            #region Enumeraciones
            /// <summary>
            /// Enumeración para distinguir tipos de campos de envio de correo
            /// </summary>
            public enum CMSFormFiledType
            {
                Short = 0,
                Long = 1
            }
            #endregion

            /// <summary>
            /// Nombre del campo
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Orden del campo
            /// </summary>
            public int Order { get; set; }

            /// <summary>
            /// Indica si el campo es obligatorio
            /// </summary>
            public bool Required { get; set; }

            /// <summary>
            /// Indica el tipo de campo
            /// </summary>
            public CMSFormFiledType FormFiledType { get; set; }
        }
    }
}
