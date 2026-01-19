using Es.Riam.Semantica;
using Es.Riam.Semantica.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica.OWL
{
    public class Ontologia
    {
        #region Propiedades

        /// <summary>
        /// Obtiene el gestorOWL
        /// </summary>
        public virtual GestionOWL GestorOWL { get; set; }

        /// <summary>
        /// Obtiene la lista de entidades de la Ontología
        /// </summary>
        public List<ElementoOntologia> Entidades { get; set; }

        public List<Propiedad> Propiedades { get; set; }

        public List<ElementoOntologia> EntidadesAuxiliares { get; set; }

        /// <summary>
        /// Tipo de entidades relacionadas con la entidad principal.
        /// </summary>
        public List<string> TiposEntidades { get; set; }

        /// <summary>
        /// Lista con los namespaces definidos para la ontología, clave-valor, 1º url, 2º namespace.
        /// </summary>
        public Dictionary<string, string> NamespacesDefinidos { get; set; }

        /// <summary>
        /// Lista con los namespaces definidos para la ontología, clave-valor, 1º namespace, 2º url.
        /// </summary>
        public Dictionary<string, string> NamespacesDefinidosInv { get; set; }

        /// <summary>
        /// Lista con los namespaces extra para la ontología, clave-valor, 1º namespace, 2º url.
        /// </summary>
        public Dictionary<string, string> NamespacesDefinidosExtra { get; set; }

        /// <summary>
        /// Lista con los valores de namespaces que hacen referencia a namespaces definidos para la ontología, valorReferencia-clave.
        /// </summary>
        public Dictionary<string, string> ValorVerdaderNamespacesReferencia { get; set; }

        /// <summary>
        /// Devuelve o establce el RDF de un CV semántico para incluirlo en el de una persona.
        /// </summary>
        public string RDFCVSemIncluido { get; set; }

        /// <summary>
        /// Devuelve o establce el valor que indicas si en la ontología se usan IDs relativos o no.
        /// </summary>
        public bool UsoIDsRelativos { get; set; }

        /// <summary>
        /// Url de las ontologías importadas.
        /// </summary>
        public List<string> UrlOntologiasImportadas { get; set; }

        #region Estilo Plantillas

        /// <summary>
        /// Estilos de la plantilla actual.
        /// </summary>
        public Dictionary<string, List<EstiloPlantilla>> EstilosPlantilla { get; set; }

        /// <summary>
        /// Configuración de la plantilla.
        /// </summary>
        //public EstiloPlantillaConfigGen ConfiguracionPlantilla { get; set; }
        private EstiloPlantillaConfigGen mConfiguracionPlantilla;
        public EstiloPlantillaConfigGen ConfiguracionPlantilla
        {
            get
            {
                if (mConfiguracionPlantilla == null)
                {
                    if (EstilosPlantilla != null)
                    {
                        foreach (EstiloPlantilla estilo in EstilosPlantilla["[ConfiguracionGeneral]"])
                        {
                            if (estilo is EstiloPlantillaConfigGen)
                            {
                                mConfiguracionPlantilla = (EstiloPlantillaConfigGen)estilo;

                                if (!this.OntoAuxiliarInventada)
                                {
                                    mConfiguracionPlantilla.Ontologia = this;
                                }

                                break;
                            }
                        }
                    }
                }

                if (mConfiguracionPlantilla != null && mConfiguracionPlantilla.Ontologia == null && !this.OntoAuxiliarInventada) // añadido para serializar
                {
                    mConfiguracionPlantilla.Ontologia = this;
                }

                return mConfiguracionPlantilla;
            }
            set { mConfiguracionPlantilla = value; }
        }


        /// <summary>
        /// Genarar namespaces si hay Urls huerfanas.
        /// </summary>
        public bool GenararNamespacesHuerfanos { get; set; }

        /// <summary>
        /// Idioma del usuario.
        /// </summary>
        public string IdiomaUsuario { get; set; }

        /// <summary>
        /// Identificador ontologia
        /// </summary>
        public Guid OntologiaID { get; set; }

        /// <summary>
        /// Lista con las ontologías externas relacionadas con la actual.
        /// </summary>
        public Dictionary<string, Ontologia> OntologiasExternas { get; set; }

        /// <summary>
        /// Indica que es una ontología auxiliar inventada para los selectores de entidad.
        /// </summary>
        public bool OntoAuxiliarInventada { get; set; }

        #endregion

        #endregion
        /// <summary>
        /// Devuelve la entidad del tipo pTipoEntidad
        /// </summary>
        /// <param name="pTipoEntidad">Tipo de la entidad buscada</param>
        /// <returns>La entidad del tipo buscado</returns>
        public virtual ElementoOntologia GetEntidadTipo(string pTipoEntidad)
        {
            return GetEntidadTipo(pTipoEntidad, true);
        }

        /// <summary>
        /// Devuelve la entidad del tipo pTipoEntidad
        /// </summary>
        /// <param name="pTipoEntidad">Tipo de la entidad buscada</param>
        /// <param name="pCrearNuevaEntidad">True si debe crearse una nueva entidad, false si debe devolverse una existente</param>
        /// <returns>La entidad del tipo buscado</returns>
        public ElementoOntologia GetEntidadTipo(string pTipoEntidad, bool pCrearNuevaEntidad)
        {
            bool encontrado = false;
            int i = 0;
            ElementoOntologia entidad = null;

            //recorro todas las entdidades
            while ((!encontrado) && (i < this.Entidades.Count))
            {
                if (Entidades[i].TipoEntidad.Equals(pTipoEntidad) || Entidades[i].TipoEntidad.Equals(GetTipoEntidadSinNamespaces(pTipoEntidad)))
                {
                    encontrado = true;
                    entidad = this.Entidades[i];
                }
                i++;
            }

            if (entidad != null)
            {
                if (pCrearNuevaEntidad)
                    return GestorOWL.CrearElementoOntologia(entidad);
                return entidad;
            }
            else
                return GestorOWL.CrearElementoOntologia(pTipoEntidad, GestorOWL.UrlOntologia, GestorOWL.NamespaceOntologia);
        }
        /// <summary>
        /// Devuelve el tipo de entidad sin namespaces de la entidad pasada como parámetro.
        /// </summary>
        /// <param name="pTipoEntidad">Tipo de entidad</param>
        /// <returns>Tipo de entidad sin namespaces de la entidad pasada como parámetro</returns>
        public string GetTipoEntidadSinNamespaces(string pTipoEntidad)
        {
            if (!pTipoEntidad.Contains("://") && pTipoEntidad.Contains(":"))
            {
                string namesp = pTipoEntidad.Substring(0, pTipoEntidad.IndexOf(":"));

                if (this.GestorOWL.NamespaceOntologia == namesp)
                {
                    string tipoEnt = pTipoEntidad.Substring(pTipoEntidad.IndexOf(":") + 1);
                    return this.GestorOWL.UrlOntologia + tipoEnt;
                }
                else if (NamespacesDefinidosInv.ContainsKey(namesp))
                {
                    string tipoEnt = pTipoEntidad.Substring(pTipoEntidad.IndexOf(":") + 1);
                    return NamespacesDefinidosInv[namesp] + tipoEnt;
                }
            }

            return pTipoEntidad;
        }
    }

}
