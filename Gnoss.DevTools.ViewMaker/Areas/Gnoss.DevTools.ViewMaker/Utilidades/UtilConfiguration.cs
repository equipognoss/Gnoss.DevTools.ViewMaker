using Gnoss.DevTools.ViewMaker.Areas.Gnoss.DevTools.ViewMaker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Gnoss.DevTools.ViewMaker.Areas.Gnoss.DevTools.ViewMaker.Utilidades
{
    public class UtilConfiguration
    {
        private const string FILE_AUTHORIZATION = "Authorization.config";
        private const string FILE_CONFIGURATION = "Configuration.config";
        private const string FILE_AUTOCOMPLETE_DATA = "AutocompleteData.config";

        //private static readonly string configDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config";
        private static readonly string configDirectory = AppContext.GetData("rutaBase") + "Config";
        private static readonly string rutaAutorization = $"{configDirectory}\\{FILE_AUTHORIZATION}";
        private static readonly string rutaConfiguration = $"{configDirectory}\\{FILE_CONFIGURATION}";
        private static readonly string rutaAutocompleteData = $"{configDirectory}\\{FILE_AUTOCOMPLETE_DATA}";

        internal static void SetConfiguracion(string key, string value)
        {
            XmlDocument docXml = ReadOrCreateXmlDocument(configDirectory, FILE_CONFIGURATION);

            XmlNode parentNode = docXml.SelectSingleNode("config");

            XmlNode node = parentNode.SelectSingleNode(key);
            if (node == null)
            {
                node = createXPath(docXml, key);
            }
            node.InnerText = value;

            SaveXmlDocument(docXml, configDirectory, FILE_CONFIGURATION);
        }

        private static XmlNode createXPath(XmlDocument doc, string xpath)
        {
            XmlNode node = doc;
            foreach (string part in xpath.Substring(1).Split('/'))
            {
                XmlNode nodeAux = node.SelectSingleNode(part);

                if (nodeAux != null) { node = nodeAux; continue; }

                if (part.StartsWith("@"))
                {
                    var anode = doc.CreateAttribute(part.Substring(1));
                    node.Attributes.Append(anode);
                    node = anode;
                }
                else
                {
                    string elName, attrib = null;
                    if (part.Contains("["))
                    {
                        SplitOnce(part, "[", out elName, out attrib);
                        if (!attrib.EndsWith("]")) throw new Exception("Unsupported XPath (missing ]): " + part);
                        attrib = attrib.Substring(0, attrib.Length - 1);
                    }
                    else elName = part;

                    XmlNode next = doc.CreateElement(elName);
                    node.AppendChild(next);
                    node = next;

                    if (attrib != null)
                    {
                        if (!attrib.StartsWith("@")) throw new Exception("Unsupported XPath attrib (missing @): " + part);
                        string name, value;
                        SplitOnce(attrib.Substring(1), "='", out name, out value);
                        if (string.IsNullOrEmpty(value) || !value.EndsWith("'")) throw new Exception("Unsupported XPath attrib: " + part);
                        value = value.Substring(0, value.Length - 1);
                        var anode = doc.CreateAttribute(name);
                        anode.Value = value;
                        node.Attributes.Append(anode);
                    }
                }
            }
            return node;
        }

        private static void SplitOnce(string value, string separator, out string part1, out string part2)
        {
            if (value != null)
            {
                int idx = value.IndexOf(separator);
                if (idx >= 0)
                {
                    part1 = value.Substring(0, idx);
                    part2 = value.Substring(idx + separator.Length);
                }
                else
                {
                    part1 = value;
                    part2 = null;
                }
            }
            else
            {
                part1 = "";
                part2 = null;
            }
        }

        internal static string GetConfiguration(string key)
        {
            if (System.IO.File.Exists(rutaConfiguration))
            {
                XmlDocument docXml = new XmlDocument();
                docXml.Load(rutaConfiguration);

                XmlNode nodeProy = docXml.SelectSingleNode($"config/{key}");
                if (nodeProy != null)
                {
                    return nodeProy.InnerText;
                }
            }
            return "";
        }

        internal static void GetAuthorization(string url, ref string user, ref string password)
        {
            KeyValuePair<string, string>? datosAuth = ObtenerAuthorizationConfig(url);
            if (!datosAuth.HasValue)
            {
                datosAuth = ObtenerAuthorizationConfig("default");
            }

            if (datosAuth.HasValue)
            {
                user = datosAuth.Value.Key;
                password = datosAuth.Value.Value;
            }
        }

        internal static void SetAuthorization(string url, string user, string password)
        {
            XmlDocument docXml = ReadOrCreateXmlDocument(configDirectory, FILE_AUTHORIZATION);

            XmlNode parentNode = docXml.SelectSingleNode("config");

            XmlNode nodeProy = parentNode.SelectSingleNode($"proyecto[@url=\"{url}\"]");
            if (nodeProy != null)
            {
                parentNode.RemoveChild(nodeProy);
            }

            XmlElement newConfig = docXml.CreateElement("proyecto");
            newConfig.SetAttribute("url", url);

            XmlElement nodeUser = docXml.CreateElement("user");
            nodeUser.InnerText = user;
            newConfig.AppendChild(nodeUser);

            XmlElement nodePass = docXml.CreateElement("pass");
            nodePass.InnerText = password;
            newConfig.AppendChild(nodePass);

            parentNode.AppendChild(newConfig);

            SaveXmlDocument(docXml,configDirectory,FILE_AUTHORIZATION);
        }

        internal static KeyValuePair<string, string>? ObtenerAuthorizationConfig(string url)
        {
            if (System.IO.File.Exists(rutaAutorization))
            {
                XmlDocument docXml = new XmlDocument();
                docXml.Load(rutaAutorization);

                XmlNode nodeProy = docXml.SelectSingleNode($"config/proyecto[@url=\"{url}\"]");
                if (nodeProy != null)
                {
                    XmlNode userNode = nodeProy.SelectSingleNode("user");
                    XmlNode passwordNode = nodeProy.SelectSingleNode("pass");

                    if (userNode != null && passwordNode != null)
                    {
                        return new KeyValuePair<string, string>(userNode.InnerText, passwordNode.InnerText);
                    }
                }
            }
            return null;
        }

        internal static List<ConfigurationModel.AutorizationModel> GetAuthorizationConfig()
        {
            List<ConfigurationModel.AutorizationModel> autorizationList = new List<ConfigurationModel.AutorizationModel>();

            if (System.IO.File.Exists(rutaAutorization))
            {
                XmlDocument docXml = new XmlDocument();
                docXml.Load(rutaAutorization);

                XmlNodeList nodesProy = docXml.SelectNodes($"config/proyecto");
                foreach (XmlNode nodeProy in nodesProy)
                {
                    XmlNode userNode = nodeProy.SelectSingleNode("user");
                    XmlNode passwordNode = nodeProy.SelectSingleNode("pass");

                    if (userNode != null && passwordNode != null)
                    {
                        ConfigurationModel.AutorizationModel autorization = new ConfigurationModel.AutorizationModel();
                        autorization.url = nodeProy.Attributes["url"].Value;
                        autorization.user = userNode.InnerText;
                        autorization.password = passwordNode.InnerText;

                        autorizationList.Add(autorization);
                    }
                }
            }
            if (!autorizationList.Any())
            {
                ConfigurationModel.AutorizationModel autorization = new ConfigurationModel.AutorizationModel();
                autorization.url = "default";
                autorization.user = "";
                autorization.password = "";

                autorizationList.Add(autorization);
            }

            return autorizationList;
        }

        internal static void SetAuthorizationConfig(List<ConfigurationModel.AutorizationModel> autorizationList)
        {
            XmlDocument docXml = new XmlDocument();

            if (!autorizationList.Any(a => a.url.Equals("default")))
            {
                docXml.LoadXml("<config>  <proyecto url=\"default\"><user></user><pass></pass></proyecto></config>");
            }
            else
            {
                docXml.LoadXml("<config></config>");
            }

            XmlNode parentNode = docXml.SelectSingleNode("config");


            foreach (ConfigurationModel.AutorizationModel autorization in autorizationList)
            {
                XmlElement newConfig = docXml.CreateElement("proyecto");
                newConfig.SetAttribute("url", autorization.url);

                XmlElement nodeUser = docXml.CreateElement("user");
                nodeUser.InnerText = autorization.user;
                newConfig.AppendChild(nodeUser);

                XmlElement nodePass = docXml.CreateElement("pass");
                nodePass.InnerText = autorization.password;
                newConfig.AppendChild(nodePass);

                parentNode.AppendChild(newConfig);
            }

            SaveXmlDocument(docXml, configDirectory, FILE_AUTHORIZATION);
        }

        internal static List<string> GetAutocompleteData(string key)
        {
            List<string> resultados = new List<string>();
            if (System.IO.File.Exists(rutaAutocompleteData))
            {
                XmlDocument docXml = new XmlDocument();
                docXml.Load(rutaAutocompleteData);

                XmlNodeList nodeList = docXml.SelectNodes($"config/{key}");
                foreach (XmlNode node in nodeList)
                {
                    resultados.Add(node.InnerText);
                }
            }
            return resultados;
        }

        internal static void SetAutocompleteData(string key, string value)
        {
            List<string> values = new List<string>();
            values.Add(value);
            SetAutocompleteData(key, values);
        }

        internal static void SetAutocompleteData(string key, List<string> values)
        {
            XmlDocument docXml = ReadOrCreateXmlDocument(configDirectory, FILE_AUTOCOMPLETE_DATA);

            XmlNode parentNode = docXml.SelectSingleNode("config");

            XmlNodeList nodeList = parentNode.SelectNodes(key);
            foreach (XmlNode node in nodeList)
            {
                parentNode.RemoveChild(node);
            }

            int order = 0;
            foreach (string nodeValue in values)
            {
                XmlNode node = createXPath(docXml, $"/config/{key}[@order='{order}']");
                node.InnerText = nodeValue;
                order++;
            }

            SaveXmlDocument(docXml, configDirectory, FILE_AUTOCOMPLETE_DATA);
        }

        private static XmlDocument ReadOrCreateXmlDocument(string directory, string fileName)
        {
            XmlDocument docXml = new XmlDocument();

            if (System.IO.File.Exists($"{directory}\\{fileName}"))
            {
                docXml.Load($"{directory}\\{fileName}");
            }
            else
            {
                docXml.LoadXml("<config></config>");
            }

            return docXml;
        }
        private static void SaveXmlDocument(XmlDocument document, string directory, string fileName)
        {
            CreateDirectoryIfNotExist(directory);
            document.Save($"{directory}\\{fileName}");
        }
        private static void CreateDirectoryIfNotExist(string directory)
        {
            if (string.IsNullOrEmpty(directory) || string.IsNullOrWhiteSpace(directory) || Directory.Exists(directory))
            {
                return;
            }

            Directory.CreateDirectory(directory);
        }

    }
}