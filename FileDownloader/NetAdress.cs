using System;
using System.Net;

namespace FileDownloader
{
    class NetAdress : _Adress
    {
        /// 
        /// Checks if adress is in accordance to URL regex.
        /// 
        protected override bool IsAdressValid(string uriName)
        {
            Uri uriResult;
            return Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
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
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
