using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Gnoss.DevTools.ViewMaker.Areas.Gnoss.DevTools.ViewMaker.Utilidades
{
    public class UtilPageCache
    {
        

        internal static string GetFileName(string pUrl)
        {
            //string fileName = pUrl.Substring(pUrl.IndexOf("//") + 2).Trim('/');

            //if (fileName.Contains("/"))
            //{
            //    fileName = pUrl.Substring(pUrl.IndexOf('/'));
            //    fileName = fileName.Replace('?', '-');
            //    fileName = fileName.Replace('&', '-');
            //    fileName = fileName.Replace('=', '-');
            //    fileName = fileName.Replace(':', '-');
            //    fileName = fileName.Replace(';', '-');
            //}
            //if (string.IsNullOrEmpty(fileName)) { fileName = "home"; }

            string fileName = GetMd5Hash(pUrl);           
          
           return Path.Combine(Directory.GetCurrentDirectory(), "App_Data", fileName + ".txt");

            //return HttpContext.Current.Server.MapPath($"~/App_Data/{fileName}.txt");
        }

        internal static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

        internal static void SaveCacheFile(string cacheFileName, string value)
        {
            // Guardamos el json obtenido en App_Data
            FileInfo file = new FileInfo(cacheFileName);
            file.Directory.Create();
            System.IO.File.WriteAllText(file.FullName, value);
        }

    }
}