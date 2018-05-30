using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public FullName(string fn, string ln)
        {
            if (String.IsNullOrWhiteSpace(fn) || String.IsNullOrWhiteSpace(ln))
                throw new ArgumentException("invalid name");
            FirstName = fn;
            LastName = ln;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
