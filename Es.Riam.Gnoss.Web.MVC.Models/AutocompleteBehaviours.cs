using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Behavior of the autocomplete text box
    /// </summary>
    public enum AutocompleteBehaviours
    {
        /// <summary>
        /// Default behaviour
        /// </summary>
        Default = 0,
        /// <summary>
        /// Show only the autocomplete text box, without items
        /// </summary>
        OnlyTextBox = 1,
    }
}
