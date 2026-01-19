using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Interfaces
{
    /// <summary>
    /// Interfaz para elemento de Gnoss
    /// </summary>
    public interface IElementoGnoss : IDisposable
    {
        /// <summary>
        /// Devuelve o establece el padre del elemento
        /// </summary>
        IElementoGnoss Padre
        {
            get;
            set;
        }

        /// <summary>
        /// Devuelve la lista de los hijos de este elemento en el nivel inmediato inferior
        /// </summary>
        List<IElementoGnoss> Hijos
        {
            get;
        }

        /// <summary>
        /// Obtiene o establece el índice del elemento actual en la lista de hijos de su padre
        /// </summary>
        short Indice
        {
            get;
            set;
        }

        /// <summary>
        /// Obtiene o establece el color representativo del elemento
        /// </summary>
        Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// Devuelve si el elemento es editable
        /// </summary>
        bool EsEditable
        {
            get;
        }

        /// <summary>
        /// Devuelve o establece el nombre del elemento
        /// </summary>
        string Nombre
        {
            get;
            set;
        }

        /// <summary>
        /// Devuelve si el elemento está siendo eliminado o no
        /// </summary>
        bool EstaEliminado
        {
            get;
        }

        /// <summary>
        /// Devuelve si se puede eliminar
        /// </summary>
        bool SePuedeEliminar
        {
            get;
        }

        /// <summary>
        /// Devuelve o establece si el elemento está seleccionado
        /// </summary>
        bool EstaSeleccionado
        {
            get;
            set;
        }

        /// <summary>
        /// Devuelve si el elemento puede expandirse o contraerse
        /// </summary>
        bool EsExtensible
        {
            get;
        }

        /// <summary>
        /// Devuelve o establece si el elemento se muestra contraido o expandido
        /// </summary>
        bool EstaContraido
        {
            get;
            set;
        }

        /// <summary>
        /// Devuelve o establece si el elemento es visible o nó en la tabla
        /// </summary>
        bool EstaVisible
        {
            get;
            set;
        }

        /// <summary>
        /// Obtiene el código del elemento
        /// </summary>
        string Codigo
        {
            get;
        }
    }
}
