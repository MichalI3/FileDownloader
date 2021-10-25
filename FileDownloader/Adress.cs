namespace FileDownloader
{
    abstract class _Adress
    {
        private string adress;
        private bool isvalid = false;

        public bool IsValid
        {
            get { return isvalid; }
        }

        public string Adress
        {
            get { return adress; }

            set
            {
                isvalid = IsAdressValid(value);
                adress = value;
            }
        }

        /// 
        /// Checks if adress is in accordance to URL regex.
        /// 
        protected abstract bool IsAdressValid(string uriName);

    }
}
