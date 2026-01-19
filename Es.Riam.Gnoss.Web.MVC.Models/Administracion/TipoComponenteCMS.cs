using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models.Administracion
{
    /// <summary>
    /// Enumeración para distinguir tipos de Componetes disponibles para el CMS
    /// </summary>
    public enum TipoComponenteCMS
    {
        /// <summary>
        /// Representa un HTML plano
        /// </summary>
        HTML = 0,
        /// <summary>
        /// Representa un HTML destacado
        /// </summary>
        Destacado = 1,
        /// <summary>
        /// Representa un listado dinamico
        /// </summary>
        ListadoDinamico = 2,
        /// <summary>
        /// Representa un listado estático
        /// </summary>
        ListadoEstatico = 3,
        /// <summary>
        /// Representa la actividad reciente
        /// </summary>
        ActividadReciente = 4,
        /// <summary>
        /// Representa un grupo de componentes
        /// </summary>
        GrupoComponentes = 5,
        /// <summary>
        /// Representa una sección del tesauro de la comunidad
        /// </summary>
        Tesauro = 6,
        ///// <summary>
        ///// Representa los recursos destacados de la comunidad
        ///// </summary>
        //RecursosDestacados = 7,
        /// <summary>
        /// Representa los datos de la comunidad, numero de recursos y personas y organizaciones
        /// </summary>
        DatosComunidad = 8,
        /// <summary>
        /// Representa los usuarios recomendados
        /// </summary>
        UsuariosRecomendados = 9,
        /// <summary>
        /// Representa una caja de buscador
        /// </summary>
        CajaBuscador = 10,
        ///// <summary>
        ///// Representa los recursos destacados estaticos de la comunidad
        ///// </summary>
        //RecursosDestacadosEstatico = 11,
        ///// <summary>
        ///// Representa un refcurso destacado
        ///// </summary>
        //RecursoDestacado = 12,
        /// <summary>
        /// Representa una faceta
        /// </summary>
        Faceta = 13,
        /// <summary>
        /// ListadoUsuarios
        /// </summary>
        ListadoUsuarios = 14,
        /// <summary>
        /// ListadoProyectos
        /// </summary>
        ListadoProyectos = 15,
        /// <summary>
        /// ResumenPerfil
        /// </summary>
        ResumenPerfil = 16,
        /// <summary>
        /// MasVistos
        /// </summary>
        MasVistos = 17,
        /// <summary>
        /// EnvioCorreo
        /// </summary>
        EnvioCorreo = 18,
        /// <summary>
        /// PreguntaTIC
        /// </summary>
        PreguntaTIC = 19,
        /// <summary>
        /// Menu
        /// </summary>
        Menu = 20,
        /// <summary>
        /// Buscador
        /// </summary>
        Buscador = 21,
        /// <summary>
        /// BuscadorSPARQL
        /// </summary>
        BuscadorSPARQL = 22,
        /// <summary>
        /// UltimosRecursosVisitados
        /// </summary>
        UltimosRecursosVisitados = 23,
        /// <summary>
        /// Ficha descripción documento
        /// </summary>
        FichaDescripcionDocumento = 24,
        /// <summary>
        /// MasVistos en x dias
        /// </summary>
        MasVistosEnXDias = 25,
        /// <summary>
        /// ConsultaSPARQL
        /// </summary>
        ConsultaSPARQL = 26,
        /// <summary>
        /// ConsultaSQLSERVER
        /// </summary>
        ConsultaSQLSERVER = 27,
        /// <summary>
        /// Listado al que se le pasan los recursos por parametros
        /// </summary>
        ListadoPorParametros = 28
    }
}
