namespace Es.Riam.Gnoss.Util.Seguridad
{
    public class Usuario
    {
        private static GnossIdentity _usuarioActual;
        public static GnossIdentity UsuarioActual
        {
            get
            {
                if (_usuarioActual == null)
                {
                    _usuarioActual = new GnossIdentity();
                }
                return _usuarioActual;
            }
        }
    }
}