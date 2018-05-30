using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class PhoneNumber
    {
        public int CityCode { get; set; }
        public int Number { get; set; }

        public PhoneNumber() : this (0, 0)
        {
        }
        public PhoneNumber (int code, int number)
        {
            CityCode = code;
            Number = number;
        }
        public override string ToString()
        {
            return $"({CityCode:0##}) {Number:0#-##-##}";
        }
    }
}
