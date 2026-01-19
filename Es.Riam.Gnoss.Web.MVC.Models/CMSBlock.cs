namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un bloque en la estructura del CMS (Una página del CMS contendrá bloques que a su vez contendran componentes)
    /// </summary>
    [Serializable]
    public partial class CMSBlock
    {
        /// <summary>
        /// Identificador del bloque padre(si tiene)
        /// </summary>
        public Guid? ParentKey { get; set; }
        /// <summary>
        /// Identificador del bloque
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// Lista de bloques contenidos dentro del bloque actual
        /// </summary>
        public List<CMSBlock> BlockList { get; set; }
        /// <summary>
        /// Lista de componentes contenidos dentro del bloque actual
        /// </summary>
        public List<CMSComponent> ComponentList { get; set; }
        /// <summary>
        /// Diccionario con atributos para incluir den el html bloque 
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
}
