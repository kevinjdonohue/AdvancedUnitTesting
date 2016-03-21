using TestDataBuilder;

namespace TestDataBuilderTests
{
    public class AddressBuilder
    {
        private string _line1 = "123 main st";
        private string _line2 = "suite 456";
        private string _city = "portland";
        private string _state = "oregon";
        private int _zipCode = 97201;

        public Address Build()
        {
            return new Address(_line1, _line2, _city, _state, _zipCode);
        }

        //Fluent API - Modification Methods:

        public AddressBuilder WithLine1(string line1)
        {
            _line1 = line1;
            return this;
        }

        public AddressBuilder WithLine2(string line2)
        {
            _line2 = line2;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            _state = state;
            return this;
        }

        public AddressBuilder WithZipCode(int zipCode)
        {
            _zipCode = zipCode;
            return this;
        }

        //Operator Overload
        public static implicit operator Address(AddressBuilder addressBuilder)
        {
            return addressBuilder.Build();
        }
    }
}
