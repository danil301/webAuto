using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Helpers
{
    public static class FileLoader
    {
        public static bool LoadByUrl(string url, string path)
        {
            try
            {
                WebClient webClient = new WebClient();
                string pdfFilePath = path;
                webClient.DownloadFile(url, pdfFilePath);
                webClient.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }           
        }
    }
}
