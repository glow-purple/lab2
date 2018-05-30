using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Employee : Person, IEquatable<Employee>, IUnit
    {
        public Organization Organization { get; private set; }
        public string Id { get; private set; }
        public Department Department { get; private set; }
        public string Position { get; set; }
        public Salary CurrentSalary { get; private set; }

        public Employee(FullName name, DateTime birthDate, string position) : base(name, birthDate)
        {
            if (String.IsNullOrWhiteSpace(position))
                throw new ArgumentException("invalid position");
            Position = position;
            CurrentSalary = new Salary();
        }
        public void AddTo(IOrgUnit dep)
        {
            Department = dep as Department;
            Organization = Department.Organization;
        }
        public void SetId(int n)
        {
            Id = Department.Id + n;
        }
        public void Remove()
        {
            Id = null;
            Department = null;
            Organization = null;
        }
        public override string ToString()
        {
            return $"id: {Id} {Name} ({DateOfBirth:d}) title: {Position} in {Department} (salary: {CurrentSalary})";
        }
        public bool Equals(Employee other)
        {
            if (other == null) return false;
            return (Id.Equals(other.Id));
        }
    }
}
