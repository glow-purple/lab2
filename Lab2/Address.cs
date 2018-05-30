using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public Address() :this ("n/a", "n/a", 0)
        {
        }
        public Address (string city, string street, int house)
        {
            City = city;
            Street = street;
            House = house;
        }
        public override string ToString()
        {
            return $"{House}, {Street}, {City}";
        }
    }
}
