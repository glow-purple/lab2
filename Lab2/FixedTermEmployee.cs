using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class FixedTermEmployee : Employee
    {
        public DateTime ContractTermination { get; private set; }
        public FixedTermEmployee(FullName name, DateTime birthDate, string position, DateTime termDate)
            : base(name, birthDate, position)
        {
            ContractTermination = termDate;
        }
        public override string ToString()
        {
            return $"id: {Id} {Name} ({DateOfBirth:d}) title: {Position} in {Department} (salary: {CurrentSalary})" +
                $" Contract terminates: {ContractTermination:d}";
        }
    }
}


