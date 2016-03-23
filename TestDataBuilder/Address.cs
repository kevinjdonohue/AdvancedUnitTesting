namespace TestDataBuilder
{
    public class Address
    {
        private readonly string _line1;
        private readonly string _line2;
        private readonly string _city;
        private readonly string _state;
        private readonly int _zipCode;

        public string Line1
        {
            get { return _line1; }

        }

        public string Line2
        {
            get { return _line2; }
        }

        public string City
        {
            get { return _city; }
        }

        public string State
        {
            get { return _state; }
        }

        public int ZipCode
        {
            get { return _zipCode; }
        }

        public Address(string line1, string line2, string city, string state, int zipCode)
        {
            _line1 = line1;
            _line2 = line2;
            _city = city;
            _state = state;
            _zipCode = zipCode;
        }
    }
}