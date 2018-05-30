using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public abstract class Person
    {
        public FullName Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        protected Person(FullName name, DateTime birthDate)
        {
            Name = name;
            DateOfBirth = birthDate;
        }
    }
}
