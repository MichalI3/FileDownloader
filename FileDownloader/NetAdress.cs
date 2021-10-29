using System;
using System.Net;
using System.Net.NetworkInformation;
namespace FileDownloader
{
    public class NetAdress : _Adress
    {
        private bool _Error404 = false;
        public bool Error404 { get { return _Error404; } }
        private string _filename;
        public string FileName{ get { return _filename; } }
        /// 
        /// Checks if adress is in accordance to URL regex.
        /// 
        public override bool IsAdressValid(string uriName)
        {
            Uri uriResult;
            
            bool b = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            
            _filename = System.IO.Path.GetFileName(uriName);

            return b;
        }

        /// 
        /// Checks if adress is reachable.
        /// 
        public bool IsInNetwork(int Timeout = 1500)
        {
            if (!IsValid) return false;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Adress);
            request.Timeout = Timeout;
            request.Method = "HEAD";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if ((response).StatusCode == HttpStatusCode.MethodNotAllowed)
                        Console.WriteLine("not allowed");

                        return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException e)
            {
                if (e.Message == "The remote server returned an error: (404) Not Found.")
                    _Error404 = true;
                return false;
            }
        }
    }
}
