using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models.Administracion
{
    public enum TipoCaducidadComponenteCMS
    {
        /// <summary>
        /// No caduca nunca
        /// </summary>
        NoCaducidad = 0,
        /// <summary>
        /// Caduca a la hora
        /// </summary>
        Hora = 1,
        /// <summary>
        /// Caduca al día
        /// </summary>
        Dia = 2,
        /// <summary>
        /// Caduca a la semana
        /// </summary>
        Semana = 3,
        /// <summary>
        /// Caduca al publicar/editrar/eliminar un recurso de la comunidad
        /// </summary>
        Recurso = 4,
        /// <summary>
        /// Caduca al registrar un usuario nuevo en la comunidad
        /// </summary>
        Persona = 5,
        /// <summary>
        /// No utiliza cache
        /// </summary>
        NoCache = 6,
    }
}
