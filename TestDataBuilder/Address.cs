﻿namespace TestDataBuilder
{
    public class Address
    {
        public string Line1 { get; }
        public string Line2 { get; }
        public string City { get; }
        public string State { get; }
        public int ZipCode { get; }

        public Address(string line1, string line2, string city, string state, int zipCode)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}