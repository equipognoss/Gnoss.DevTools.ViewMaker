using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models.Administracion
{
    /// <summary>
    /// Enumeración para distinguir tipos de propiedades de los Componetes disponibles para el CMS
    /// </summary>
    public enum TipoPropiedadCMS
    {
        /// <summary>
        /// Representa un HTML plano
        /// </summary>
        HTML = 0,
        /// <summary>
        /// Representa el título
        /// </summary>
        Titulo = 1,
        /// <summary>
        /// URL de una imagen
        /// </summary>
        Imagen = 2,
        /// <summary>
        /// URL de un enlace
        /// </summary>
        Enlace = 3,
        /// <summary>
        /// URL de una búsqueda
        /// </summary>
        URLBusqueda = 4,
        /// <summary>
        /// Número de Itmes
        /// </summary>
        NumItems = 5,
        /// <summary>
        /// Listado de GUIDs separados por comas
        /// </summary>
        ListaIDs = 6,
        /// <summary>
        /// Tipo de busqueda
        /// </summary>
        //TipoDeBusqueda = 7,
        /// <summary>
        /// Guid de un elemento
        /// </summary>
        ElementoID = 8,
        /// <summary>
        /// Indica si tiene imagen
        /// </summary>
        TieneImagen = 9,
        /// <summary>
        /// Indica el tipo de actividad reciente
        /// </summary>
        TipoActividadRecienteCMS = 10,
        /// <summary>
        /// Número de Itmes para mostrar
        /// </summary>
        NumItemsMostrar = 11,
        /// <summary>
        /// Tipo presentación recursos
        /// </summary>
        TipoPresentacionRecurso = 12,
        /// <summary>
        /// Texto por defecto
        /// </summary>
        TextoDefecto = 13,
        /// <summary>
        /// Indica si tiene boton hazte miembro
        /// </summary>
        TieneBotonHazteMiembro = 14,
        /// <summary>
        /// Tipo presentación grupo de componentes
        /// </summary>
        TipoPresentacionGrupoComponentes = 15,
        /// <summary>
        /// Representa el Subtitulo
        /// </summary>
        Subtitulo = 16,
        /// <summary>
        /// Tipo presentación para listado de recursos
        /// </summary>
        TipoPresentacionListadoRecursos = 17,
        /// <summary>
        /// Tipo presentación para listado de usuarios
        /// </summary>
        TipoPresentacionListadoUsuarios = 18,
        /// <summary>
        /// Tipo de listado de usuarios
        /// </summary>
        TipoListadoUsuarios = 19,
        /// <summary>
        /// Pestanya
        /// </summary>
        //Pestanya = 20,
        /// <summary>
        /// Faceta
        /// </summary>
        Faceta = 21,
        /// <summary>
        /// Tipo de presentacion de faceta
        /// </summary>
        TipoPresentacionFaceta = 22,
        /// <summary>
        /// Ver mas
        /// </summary>
        VerMas = 23,
        /// <summary>
        /// Tipo de listado de proyectos
        /// </summary>
        TipoListadoProyectos = 24,
        /// <summary>
        /// Lista de campos de envío de correo
        /// </summary>
        ListaCamposEnvioCorreo = 25,
        /// <summary>
        /// Texto para un botón
        /// </summary>
        TextoBoton = 26,
        /// <summary>
        /// Texto con el destinatario de envío del correo
        /// </summary>
        DestinatarioCorreo = 27,
        /// <summary>
        /// Texto mensaje todo correcto
        /// </summary>
        TextoMensajeOK = 28,
        /// <summary>
        /// Para mostrar todas las personas
        /// </summary>
        ContarPersonasNoVisibles = 29,
        /// <summary>
        /// Lista de campos 
        /// </summary>
        ListaOpcionesMenu = 30,
        /// <summary>
        /// Valor seleccionado
        /// </summary>
        ValorSeleccionado = 31,
        /// <summary>
        /// Atributo de busqueda
        /// </summary>
        AtributoDeBusqueda = 32,
        /// <summary>
        /// Título del Atributo de busqueda
        /// </summary>
        TituloAtributoDeBusqueda = 33,
        /// <summary>
        /// Personalizacion
        /// </summary>
        Personalizacion = 34,
        /// <summary>
        /// Personalizacion
        /// </summary>
        URLVerMas = 35,
        /// <summary>
        /// QuerySPARQL
        /// </summary>
        QuerySPARQL = 36,
        /// <summary>
        /// NumDias
        /// </summary>
        NumDias = 37,
        /// <summary>
        /// QuerySQLSERVER
        /// </summary>
        QuerySQLSERVER = 38,
    }

}
