using System.Runtime.Serialization;
using System.Xml;

namespace Es.Riam.Gnoss.Recursos
{
    [Serializable]
    public class UtilIdiomasSerializable : ISerializable
    {
        #region Miembros

        private string mCode = "";
        private bool mTraerDeCache = false;

        private static volatile Dictionary<Guid, List<LanguajeText>> PersonalizacionIdiomaPersonalizacion = new Dictionary<Guid, List<LanguajeText>>();
        private static volatile Dictionary<Guid, List<LanguajeText>> PersonalizacionIdiomaProyecto = new Dictionary<Guid, List<LanguajeText>>();
        private static volatile List<LanguajeText> PersonalizacionIdiomaPlataforma = new List<LanguajeText>();

        private string mPaginaActual = "";
        private XmlDocument mDocumento = null; // mtexto
        private XmlDocument mDocumento_Personalizado = null; // mtextoPersonalizado
        private XmlNode mPage = null;

        private string IdiomaDefecto = "es";
        private UtilIdiomasSerializable UtilIdiomasDefecto = null;
        private string IdiomaUsuario = "";
        private string mDirectorioLenguajes = "";
        private string[] mPreferenciasLenguajes;
        private string mFileName;

        private Guid mProyectoID = Guid.Empty;
        private Guid mPersonalizacionID = Guid.Empty;
        private Guid mPersonalizacionEcosistemaID = Guid.Empty;

        #endregion

        #region Propiedades

        public string LanguageCode
        {
            get
            {
                return mCode;
            }
        }

        public bool TraerDeCache
        {
            get { return mTraerDeCache; }
            set { mTraerDeCache = value; }
        }

        #endregion

        #region Constructores

        public UtilIdiomasSerializable()
        {
        }

        public UtilIdiomasSerializable(string pCode, bool pTraerDeCache)
        {
            mCode = pCode;
            mTraerDeCache = pTraerDeCache;
        }

        public UtilIdiomasSerializable(string pCode, bool pTraerDeCache, string pTexto, string pTextoPersonalizado,
            Dictionary<Guid, List<LanguajeText>> pPersonalizacionIdiomaProyecto, List<LanguajeText> pPersonalizacionIdiomaPlataforma, Dictionary<Guid, List<LanguajeText>> pPersonalizacionIdiomaPersonalizacion,
            Guid pProyectoID, Guid pPersonalizacionID, Guid pPersonalizacionEcosistemaID, string pIdiomaUsuario, string pDirectorioLenguajes, string pFileName, XmlNode pPage, string pPaginaActual, string[] pPreferenciasLenguajes)
        {
            mCode = pCode;
            mTraerDeCache = pTraerDeCache;

            mDocumento = new XmlDocument();
            mDocumento.Load(new StringReader(pTexto));
            //mTexto = pTexto;
            mDocumento_Personalizado = new XmlDocument();
            mDocumento_Personalizado.Load(new StringReader(pTextoPersonalizado));
            //mTextoPersonalizado = pTextoPersonalizado;
            PersonalizacionIdiomaProyecto = pPersonalizacionIdiomaProyecto;
            PersonalizacionIdiomaPlataforma = pPersonalizacionIdiomaPlataforma;
            PersonalizacionIdiomaPersonalizacion = pPersonalizacionIdiomaPersonalizacion;

            mProyectoID = pProyectoID;
            mPersonalizacionID = pPersonalizacionID;
            mPersonalizacionEcosistemaID = pPersonalizacionEcosistemaID;

            IdiomaUsuario = pIdiomaUsuario;
            mDirectorioLenguajes = pDirectorioLenguajes;
            mFileName = pFileName;
            mPage = pPage;
            mPaginaActual = pPaginaActual;
            mPreferenciasLenguajes = pPreferenciasLenguajes;
        }

        public UtilIdiomasSerializable(string pClaveIdioma, Guid pProyectoID, Guid pPersonalizacionID, Guid pPersonalizacionEcosistemaID)
        {
            mProyectoID = pProyectoID;
            mPersonalizacionID = pPersonalizacionID;
            mPersonalizacionEcosistemaID = pPersonalizacionEcosistemaID;

            mDirectorioLenguajes = "";
            mPreferenciasLenguajes = new string[0];
            IdiomaUsuario = pClaveIdioma;
            //LoadFile(); 
        }

        /// <summary>
        /// Constructor para la deseralización
        /// </summary>
        /// <param name="info">Datos serializados</param>
        /// <param name="context">Contexto de serialización</param>
        protected UtilIdiomasSerializable(SerializationInfo info, StreamingContext context)
        {
            mCode = (string)info.GetValue("Code", typeof(string));
            mTraerDeCache = (bool)info.GetValue("TraerDeCache", typeof(bool));
            mDocumento = (XmlDocument)info.GetValue("Documento", typeof(XmlDocument)); //mTexto = pTexto;
            mDocumento_Personalizado = (XmlDocument)info.GetValue("Documento_Personalizado", typeof(XmlDocument)); //mTextoPersonalizado = pTextoPersonalizado;

            PersonalizacionIdiomaProyecto = (Dictionary<Guid, List<LanguajeText>>)info.GetValue("PersonalizacionIdiomaProyecto", typeof(Dictionary<Guid, List<LanguajeText>>));
            PersonalizacionIdiomaPlataforma = (List<LanguajeText>)info.GetValue("PersonalizacionIdiomaPlataforma", typeof(List<LanguajeText>));
            PersonalizacionIdiomaPersonalizacion = (Dictionary<Guid, List<LanguajeText>>)info.GetValue("PersonalizacionIdiomaPersonalizacion", typeof(Dictionary<Guid, List<LanguajeText>>));
            mProyectoID = (Guid)info.GetValue("ProyectoID", typeof(Guid));
            mPersonalizacionID = (Guid)info.GetValue("PersonalizacionID", typeof(Guid));
            mPersonalizacionEcosistemaID = (Guid)info.GetValue("PersonalizacionEcosistemaID", typeof(Guid));

            IdiomaUsuario = (string)info.GetValue("IdiomaUsuario", typeof(string));
            mDirectorioLenguajes = (string)info.GetValue("DirectorioLenguajes", typeof(string));
            mFileName = (string)info.GetValue("FileName", typeof(string));
            mPage = (XmlDocument)info.GetValue("Page", typeof(XmlDocument));
            mPaginaActual = (string)info.GetValue("PaginaActual", typeof(string));
            mPreferenciasLenguajes = (string[])info.GetValue("PreferenciasLenguajes", typeof(string[]));

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Selecciona la página pasada por parámetro como página actual
        /// </summary>
        /// <param name="pPage">Página de un documento</param>
        public void SetPage(string pPage)
        {
            if (mPaginaActual == pPage)
                return;

            mPage = null;
            mPaginaActual = "";

            if (mDocumento != null)
            {
                mPage = mDocumento.SelectSingleNode(string.Format("//page[@name='{0}']", pPage.ToUpper()));
                mPaginaActual = pPage;
            }

            if (mDocumento_Personalizado != null)
            {
                XmlNode nodo_personalizado = mDocumento_Personalizado.SelectSingleNode(string.Format("//page[@name='{0}']", pPage.ToUpper()));
                if (nodo_personalizado != null)
                {
                    if (mPage != null)
                    {
                        mPage.InnerXml += nodo_personalizado.InnerXml;
                    }
                    else
                    {
                        mPage = nodo_personalizado;
                    }
                }
            }
        }

        private string BuscarTextoPersonalizadoVistas(Guid pClavePersonalizacion, string pTextoID)
        {
            if (pClavePersonalizacion != Guid.Empty && PersonalizacionIdiomaPersonalizacion.ContainsKey(pClavePersonalizacion) && PersonalizacionIdiomaPersonalizacion[pClavePersonalizacion].Count > 0)
            {
                LanguajeText textoPersonalizado = PersonalizacionIdiomaPersonalizacion[pClavePersonalizacion].Find(textoIdioma => textoIdioma.ClaveTexto == pTextoID);

                if (textoPersonalizado != null)
                {
                    if (textoPersonalizado.TextoIdioma.ContainsKey(LanguageCode))
                    {
                        return textoPersonalizado.TextoIdioma[LanguageCode];
                    }
                    else
                    {
                        if (LanguageCode.Contains("-"))
                        {
                            string LanguageCodeAux = LanguageCode.Substring(0, LanguageCode.IndexOf('-'));

                            if (textoPersonalizado.TextoIdioma.ContainsKey(LanguageCodeAux))
                            {
                                return textoPersonalizado.TextoIdioma[LanguageCodeAux];
                            }
                        }

                        if (textoPersonalizado.TextoIdioma.ContainsKey(IdiomaDefecto))
                        {
                            return textoPersonalizado.TextoIdioma[IdiomaDefecto];
                        }
                        else
                        {
                            return textoPersonalizado.TextoIdioma.Values.First();
                        }
                    }
                }
            }

            return null;
        }

        private string BuscarTextoPersonalizadoProyecto(string pTextoID)
        {
            if (mProyectoID != Guid.Empty && PersonalizacionIdiomaProyecto.ContainsKey(mProyectoID) && PersonalizacionIdiomaProyecto[mProyectoID].Count > 0)
            {
                LanguajeText textoPersonalizado = PersonalizacionIdiomaProyecto[mProyectoID].Find(textoIdioma => textoIdioma.ClaveTexto == pTextoID);

                if (textoPersonalizado != null)
                {
                    if (textoPersonalizado.TextoIdioma.ContainsKey(LanguageCode))
                    {
                        return textoPersonalizado.TextoIdioma[LanguageCode];
                    }
                    else if (textoPersonalizado.TextoIdioma.ContainsKey(IdiomaDefecto))
                    {
                        return textoPersonalizado.TextoIdioma[IdiomaDefecto];
                    }
                    else
                    {
                        return textoPersonalizado.TextoIdioma.Values.First();
                    }
                }
            }

            return null;
        }

        private string BuscarTextoPersonalizadoPlataforma(string pTextoID)
        {
            if (PersonalizacionIdiomaPlataforma.Count > 0)
            {
                LanguajeText textoPersonalizado = PersonalizacionIdiomaPlataforma.Find(textoIdioma => textoIdioma.ClaveTexto == pTextoID);

                if (textoPersonalizado != null)
                {
                    if (textoPersonalizado.TextoIdioma.ContainsKey(LanguageCode))
                    {
                        return textoPersonalizado.TextoIdioma[LanguageCode];
                    }
                    else if (textoPersonalizado.TextoIdioma.ContainsKey(IdiomaDefecto))
                    {
                        return textoPersonalizado.TextoIdioma[IdiomaDefecto];
                    }
                    else
                    {
                        return textoPersonalizado.TextoIdioma.Values.First();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Busca el texto personalizado para el TextoID dado
        /// </summary>
        /// <param name="pTextoID">TextoID del texto personalizado a guardar</param>
        /// <returns>Cadena de texto</returns>
        public string GetTextoPersonalizado(string pTextoID, params string[] parametros)
        {
            string texto = null;

            if (PersonalizacionIdiomaPersonalizacion.Count > 0)
            {
                texto = BuscarTextoPersonalizadoVistas(mPersonalizacionID, pTextoID);

                if (texto == null)
                {
                    texto = BuscarTextoPersonalizadoVistas(mPersonalizacionEcosistemaID, pTextoID);
                }
            }

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.Replace('{', '<').Replace('}', '>');
            }

            if (!string.IsNullOrEmpty(texto) && parametros != null && parametros.Length > 0)
            {
                texto = string.Format(texto, parametros);

                if (texto != null && parametros.Length > 0)
                {
                    for (int i = 0; i < parametros.Length; i++)
                    {
                        texto = texto.Replace("@" + (i + 1) + "@", parametros[i]);
                    }
                }
            }

            return texto;
        }

        /// <summary>
        /// Busca el texto pasado por parámetro en un documento
        /// </summary>
        /// <param name="pText">Texto</param>
        /// <returns>Cadena de texto</returns>
        private string GetText(string pText)
        {
            string texto = null;

            texto = BuscarTextoPersonalizadoProyecto(mPaginaActual + "/" + pText);

            if (texto == null)
            {

                texto = BuscarTextoPersonalizadoPlataforma(mPaginaActual + "/" + pText);
            }

            if (string.IsNullOrEmpty(texto))
            {
                pText = pText.ToUpper(new System.Globalization.CultureInfo("en"));

                if (mDocumento == null)
                    return "";

                XmlNode el = null;

                if (mPage != null)
                {
                    el = mPage.SelectSingleNode(string.Format("Resource[@tag='{0}']", pText));
                    // if in page subnode the text doesn't exist, try in whole file
                    if (el == null)
                    {
                        el = mDocumento.SelectSingleNode(string.Format("//Resource[@tag='{0}']", pText));
                    }
                }
                else
                {
                    el = mDocumento.SelectSingleNode(string.Format("//Resource[@tag='{0}']", pText));
                }

                if (el != null)
                {
                    texto = el.InnerText;
                }
            }

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.Replace('{', '<').Replace('}', '>');

                if (texto.Equals("[NULL]"))
                {
                    texto = string.Empty;
                }

                if (mPaginaActual.ToLower() == "urlsem")
                {
                    texto = texto.ToLower();
                }
                return texto;
            }
            else
            {
                if (mCode.Equals(IdiomaDefecto))
                {
                    return null;
                }
                else
                {
                    if (UtilIdiomasDefecto == null)
                    {
                        UtilIdiomasDefecto = new UtilIdiomasSerializable("es", mProyectoID, mPersonalizacionID, mPersonalizacionEcosistemaID); //igual usar constructor grande
                    }
                    return UtilIdiomasDefecto.GetText(mPaginaActual, pText);
                }
            }
        }

        /// <summary>
        /// Obtiene el texto de una clave guardada en HTML
        /// </summary>
        /// <param name="pClave">Clave guardada en HTML</param>
        /// <returns>Texto en el idioma solicitado</returns>
        public string GetTextClaveHTML(string pClave)
        {
            string separador = ",|,";

            string[] arrayClave = pClave.Replace("@#@$", "").Replace("$@#@", "").Split(new string[] { separador }, StringSplitOptions.RemoveEmptyEntries);

            string page = arrayClave[0];
            string text = arrayClave[1];

            string[] parametros = new string[] { };
            if (arrayClave.Length > 2)
            {
                string separador2 = ";|;";
                parametros = arrayClave[2].Split(new string[] { separador2 }, StringSplitOptions.RemoveEmptyEntries);
            }

            SetPage(page);

            return GetText(text, parametros);
        }

        /// <summary>
        /// Obtiene una clave para insertarla en el HTML y reemplazarla luego
        /// </summary>
        /// <param name="pPage">Etiqueta de la página en el fichero de idioma </param>
        /// <param name="pText">Etiqueta del texto en el fichero de idioma</param>
        /// <returns>Clave para insertarla en el HTML y reemplazarla luego</returns>
        private string GetClaveText(string pPage, string pText)
        {
            string separador = ",|,";
            string clave = pPage + separador + pText;

            return "@#@$" + clave + "$@#@";
        }

        /// <summary>
        /// Obtiene una clave para insertarla en el HTML y reemplazarla luego
        /// </summary>
        /// <param name="pPage">Etiqueta de la página en el fichero de idioma </param>
        /// <param name="pText">Etiqueta del texto en el fichero de idioma</param>
        /// <param name="pParametros">Parámetros</param>
        /// <returns>Clave para insertarla en el HTML y reemplazarla luego</returns>
        public string GetClaveText(string pPage, string pText, params string[] pParametros)
        {
            string separador = ",|,";
            string clave = pPage + separador + pText + separador;

            if (pParametros.Length > 0)
            {
                string separador2 = ";|;";
                for (int i = 0; i < pParametros.Length; i++)
                {
                    clave = clave + separador2 + pParametros[i];
                }
            }

            return "@#@$" + clave + "$@#@";
        }

        /// <summary>
        /// Busca el texto pasado por parámetro en la página indicada de un documento
        /// </summary>
        /// <param name="pPage">Página de un documento</param>
        /// <param name="pText">Texto</param>
        /// <param name="pProyectoID">Identificador del proyecto actual</param>
        /// <returns>Cadena de texto</returns>
        public string GetText(string pPage, string pText)
        {
            if (TraerDeCache)
            {
                return GetClaveText(pPage, pText);
            }
            else
            {
                SetPage(pPage);
                return GetText(pText);
            }
        }

        /// <summary>
        /// Busca el texto pasado por parámetro en la página indicada de un documento
        /// </summary>
        /// <param name="pPage">Página de un documento</param>
        /// <param name="pText">Texto</param>
        /// <param name="pParametros">Parámetros</param>
        /// <param name="pProyectoID">Identificador del proyecto actual</param>
        /// <returns>Cadena de texto</returns>
        public string GetText(string pPage, string pText, params string[] pParametros)
        {
            if (TraerDeCache)
            {
                return GetClaveText(pPage, pText, pParametros);
            }
            else
            {
                SetPage(pPage);
                return GetText(pText, pParametros);
            }
        }

        /// <summary>
        /// Busca el texto pasado por parámetro en la página indicada de un documento
        /// </summary>
        /// <param name="pText">Texto</param>
        /// <param name="pParametros">Parámetros</param>
        /// <returns>Cadena de texto</returns>
        private string GetText(string pText, params string[] pParametros)
        {
            string texto = GetText(pText);
            if (texto != null && pParametros.Length > 0)
            {
                for (int i = 0; i < pParametros.Length; i++)
                {
                    texto = texto.Replace("@" + (i + 1) + "@", pParametros[i]);
                }
            }
            return texto;
        }

        /// <summary>
        /// Obtiene todos los nodos de un archivo XML en forma de diccionario de la manera (clave -> valor)
        /// </summary>
        /// <param name="pPage">Página</param>
        /// <returns>Diccionario</returns>
        public Dictionary<string, string> ObtenerDiccionarioDePagina(string pPage)
        {
            SetPage(pPage);
            Dictionary<string, string> mLista = new Dictionary<string, string>();

            if (mDocumento == null)
                return null;

            XmlNodeList el = null;

            #region Pagina x defecto

            //string contenido = "";
            //switch (IdiomaDefecto)
            //{
            //    case "es":
            //        contenido = TextosEs;
            //        break;
            //    case "en":
            //        contenido = TextosEn;
            //        break;
            //    case "pt":
            //        contenido = TextosPt;
            //        break;
            //    case "de":
            //        contenido = TextosDe;
            //        break;
            //    case "fr":
            //        contenido = TextosFr;
            //        break;
            //    case "it":
            //        contenido = TextosIt;
            //        break;
            //    case "ca":
            //        contenido = TextosCa;
            //        break;
            //    case "eu":
            //        contenido = TextosEu;
            //        break;
            //    case "gl":
            //        contenido = TextosGl;
            //        break;
            //    default:
            //        contenido = TextosEs;
            //        break;
            //}

            //XmlDocument docDefecto = new XmlDocument();
            //docDefecto.Load(new StringReader(contenido));

            //XmlNode nodoDefecto = docDefecto.SelectSingleNode(string.Format("//page[@name='{0}']", pPage.ToUpper()));
            #endregion

            // cambiado de por defecto
            XmlNode nodoDefecto = mDocumento.SelectSingleNode(string.Format("//page[@name='{0}']", pPage.ToUpper()));

            if (mPage != null)
            {
                el = mPage.ChildNodes;
                foreach (XmlNode nodo in el)
                {
                    if (!string.IsNullOrEmpty(nodo.InnerText) && !mLista.ContainsKey(nodo.InnerText))
                    {
                        mLista.Add(nodo.InnerText, nodo.Attributes[0].Value);
                    }
                    else
                    {
                        XmlNode nodoDefectoHijo = nodoDefecto.SelectSingleNode(string.Format("Resource[@tag='{0}']", nodo.Attributes[0].Value.ToUpper()));
                        // if in page subnode the text doesn't exist, try in whole file
                        if (nodoDefectoHijo != null && !mLista.ContainsKey(nodoDefectoHijo.InnerText))
                        {
                            mLista.Add(nodoDefectoHijo.InnerText, nodoDefectoHijo.Attributes[0].Value);
                        }
                    }
                }
            }
            return mLista;
        }

        /// <summary>
        /// Obtiene la url de una imagen pasada por parámetro con idioma
        /// </summary>
        /// <param name="pAplicationPath">Path de la aplicación</param>
        /// <param name="pImage">Cadena de texto con el nombre de la imagen</param>
        /// <returns></returns>
        public string GetImagePath(string pAplicationPath, string pImage)
        {
            return pAplicationPath + "language/img/" + LanguageCode + "/" + pImage;
        }

        #endregion

        #region Miembros de ISerializable

        /// <summary>
        /// Metodo para serializar el objeto
        /// </summary>
        /// <param name="info">Datos serializados</param>
        /// <param name="context">Contexto de serialización</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Code", mCode);
            info.AddValue("TraerDeCache", mTraerDeCache);
            info.AddValue("Documento", mDocumento); //mTexto = pTexto;
            info.AddValue("Documento_Personalizado", mDocumento_Personalizado); //mTextoPersonalizado = pTextoPersonalizado;

            info.AddValue("PersonalizacionIdiomaProyecto", PersonalizacionIdiomaProyecto);
            info.AddValue("PersonalizacionIdiomaPlataforma", PersonalizacionIdiomaPlataforma);
            info.AddValue("PersonalizacionIdiomaPersonalizacion", PersonalizacionIdiomaPersonalizacion);
            info.AddValue("ProyectoID", mProyectoID);
            info.AddValue("PersonalizacionID", mPersonalizacionID);
            info.AddValue("PersonalizacionEcosistemaID", mPersonalizacionEcosistemaID);

            info.AddValue("IdiomaUsuario", IdiomaUsuario);
            info.AddValue("DirectorioLenguajes", mDirectorioLenguajes);
            info.AddValue("FileName", mFileName);
            info.AddValue("Page", mPage);
            info.AddValue("PaginaActual", mPaginaActual);
            info.AddValue("PreferenciasLenguajes", mPreferenciasLenguajes);
        }

        #endregion
    }
}
