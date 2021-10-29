using System.IO;

namespace FileDownloader
{
    public class DirectoryAdress : _Adress
    {
        public override bool IsAdressValid(string uriName)
        {
            return Directory.Exists(uriName);
        }
    }
}
