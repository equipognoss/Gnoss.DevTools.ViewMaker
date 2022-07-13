using System;

namespace Gnoss.DevTools.ViewMaker.Areas.Gnoss.DevTools.ViewMaker.Fake
{
    public class ProyectoAD
    {
        private static Guid mMetaproyecto = new Guid("11111111-1111-1111-1111-111111111111");
        public static Guid MetaProyecto
        {
            get
            {
                return mMetaproyecto;
            }
        }
    }
}
