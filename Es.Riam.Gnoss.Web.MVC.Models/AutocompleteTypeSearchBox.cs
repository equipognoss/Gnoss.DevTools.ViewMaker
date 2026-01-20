using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Tipo del autocompletar
    /// </summary>
    public enum AutocompleteTypeSearchBox
    {
        /// <summary>
        /// Sin autocompletar
        /// </summary>
        None = 0,
        /// <summary>
        /// Autocompleta en la Bandeja del usuaro (mensaje, invitaciones...)
        /// </summary>
        AutocompleteUser = 1,
        /// <summary>
        /// Busca en sqlserver, se activa cuando no hay filtros
        /// </summary>
        AutocompleteTipedTags = 2,
        /// <summary>
        /// Autocompleta una faceta desde virtuoso cuando hay filtros (En el MetaProyecto)
        /// </summary>
        AutocompleteGeneric = 3,
        /// <summary>
        /// Autocompleta una faceta desde virtuoso cuando hay filtros (En una comunidad que no sea el MetaProyecto)
        /// </summary>
        AutocompleteGenericWithContextFilter = 4
    }
}
