using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Enumeración con los tipos de cajas de una faceta
    /// </summary>
    public enum SearchBoxType
    {
        /// <summary>
        /// Sin caja de búsqeuda
        /// </summary>
        None = 0,
        /// <summary>
        /// Caja simple
        /// </summary>
        Simple = 1,
        /// <summary>
        /// Caja fechas desde-hasta
        /// </summary>
        FromToDates = 2,
        /// <summary>
        /// Caja rangos desde-hasta
        /// </summary>
        FromToRank = 3,
        /// <summary>
        /// Caja calendario
        /// </summary>
        Calendar = 4,
        /// <summary>
        /// Caja arbol-lista (por defecto siempre Arbol primero)
        /// </summary>
        TreeList = 5,
        /// <summary>
        /// Caja Rango Desde
        /// </summary>
        FromRank = 6,
        /// <summary>
        /// Caja Rango Hasta
        /// </summary>
        ToRank = 7,
        /// <summary>
        /// Caja calendario con rangos
        /// </summary>
        RankCalendar = 8,
        /// <summary>
        /// Caja arbol-lista
        /// </summary>
        ListTree = 9
    }
}
