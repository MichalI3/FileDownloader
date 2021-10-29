using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileDownloader
{
    public class FileDownloader
    {
        private HttpClient client;
        private Stream fStream;
        public FileDownloader() {
           client = new ();
            
        }
        public FileDownloader(HttpClient webClient, FileStream bodyFile)
        {
            client = webClient;
            fStream = bodyFile;
        }


        public async Task DownloadFile(string address, string location)
        {

            //send  request asynchronously
            HttpResponseMessage response = await client.GetAsync(address);

            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();

           

            using (FileStream fileStream = new FileStream(location, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //copy the content from response to filestream
                await response.Content.CopyToAsync(fileStream);
            }
        }

        
    }
}
