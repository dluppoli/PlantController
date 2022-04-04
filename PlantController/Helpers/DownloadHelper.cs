using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlantController.Helpers
{
    public class DownloadHelper
    {
        public bool DownloadFile(string fileUrl, string fileDestination)
        {
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(fileUrl, fileDestination);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
