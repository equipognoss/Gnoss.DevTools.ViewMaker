using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GnossTestView.Extensions
{
    public class ProyectoAD
    {
        private static Guid mMetaProyecto = new Guid("11111111-1111-1111-1111-111111111111");

        public static Guid MetaProyecto
        {
            get
            {
                return mMetaProyecto;
            }
            set
            {
                mMetaProyecto = value;
            }
        }
    }
}