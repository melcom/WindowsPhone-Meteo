namespace MeteoWP.Message
{
    public class UriParameter
    {
        private readonly string name;
        private readonly string value;

        public UriParameter(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name
        {
            get { return name; }
        }

        public string Value
        {
            get { return value; }
        }
    }
}