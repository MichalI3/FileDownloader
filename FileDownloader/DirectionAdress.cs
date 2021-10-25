using System.IO;

namespace FileDownloader
{
    class DirectionAdress : _Adress
    {
        protected override bool IsAdressValid(string uriName)
        {
            return Directory.Exists(uriName);
        }
    }
}
