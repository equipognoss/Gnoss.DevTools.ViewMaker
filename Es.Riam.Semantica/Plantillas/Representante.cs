using Es.Riam.Semantica.OWL;

namespace Es.Riam.Semantica.Plantillas
{
    /// <summary>
    /// Representante entidad.
    /// </summary>
    /// 
    [Serializable]
    public class Representante
    {
        /// <summary>
        /// Propiedad.
        /// </summary>
        public Propiedad Propiedad {  get; set; }


        /// <summary>
        /// Nombre de la Propiedad.
        /// </summary>
        public string NombrePropiedad { get; set; }

        /// <summary>
        /// Tipo de representación de las entidades.
        /// </summary>
        public TipoRepresentacion TipoRepres { get; set; }

        /// <summary>
        /// Número de caracteres del recorte.
        /// </summary>
        public int NumCaracteres { get; set; }
    }
}
