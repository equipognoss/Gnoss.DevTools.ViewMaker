using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de una faceta
    /// </summary>
    public partial class FacetModel
    {
        /// <summary>
        /// ID del tesauro
        /// </summary>
        public Guid ThesaurusID { get; set; }
        /// <summary>
        /// Indica si hay que mostrar un ver mas
        /// </summary>
        public bool SeeMore { get; set; }
        /// <summary>
        /// ID de la faceta
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Nombre de la faceta
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Identificador de la faceta
        /// </summary>
        public string FacetKey { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Indica si se trata de una faceta MultiIdioma
        /// </summary>
        public string Multilanguage { get; set; }
        /// <summary>
        /// Tipo de la caja de búsqueda
        /// </summary>
        public SearchBoxType SearchBoxType { get; set; }
        /// <summary>
        /// Tipo de autocompletar de la caja de búsqueda
        /// </summary>
        public AutocompleteTypeSearchBox AutocompleteTypeSearchBox { get; set; }
        /// <summary>
        /// Listado de los items de la facetas
        /// </summary>
        public List<FacetItemModel> FacetItemList { get; set; }
        /// <summary>
        /// Listado de grupos agrupados
        /// </summary>
        public Dictionary<string, List<string>> GroupedGroups { get; set; }
        /// <summary>
        /// Indica si es una faceta agrupada
        /// </summary>
        public bool FacetGrouped { get; set; }

        public AutocompleteBehaviours AutocompleteBehaviour { get; set; }

        /// <summary>
        /// Indica si la faceta se muestra aunque no contenga ningún item
        /// </summary>
        public bool ShowWithoutItems { get; set; }

        /// <summary>
        /// Indica si la petición era para traerse una única faceta
        /// </summary>
        public bool OneFacetRequest { get; set; }

        /// <summary>
        /// Si la faceta está dividida, aquí se almacena el valor del filtro que cumplen los valores de esta faceta.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Almacena la consulta que se realiza para obtener los datos de la faceta
        /// </summary>
        public string Query { get; set; }

    }
}
