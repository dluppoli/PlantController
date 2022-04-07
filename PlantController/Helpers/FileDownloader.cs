using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlantController.Helpers
{
    class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string fileUrl, string fileDestination)
        {
            WebClient client = new WebClient();
            client.DownloadFile(fileUrl, fileDestination);
        }
    }
}
