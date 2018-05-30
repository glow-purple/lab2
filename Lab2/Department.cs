using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Department : IEquatable<Department>, IUnit, IOrgUnit
    {
        public List<Employee> Employees { get; private set; }
        public Organization Organization { get; private set; }
        public string Id { get; private set; }
        public string Name { get; set; }
        public PhoneNumber Phone { get; set; }
        public DepartmentType Type { get; }

        public Department(DepartmentType type) : this(type, new PhoneNumber())
        {
        }
        public Department(string name)
        {
            Type = (DepartmentType)Enum.Parse(typeof(DepartmentType), name, true);
            Phone = new PhoneNumber();
            Name = Type.ToString();
        }
        public Department(DepartmentType type, PhoneNumber phone)
        {
            Type = type;
            Name = type.ToString();
            Phone = phone;
            Employees = new List<Employee>();
            Id = type.ToString().Substring(0, 1);
        }

        public void AddEmployee(Employee emp)
        {
            emp.AddTo(this);
            emp.SetId(Employees.Count() + 1);
            Employees.Add(emp);
        }
        public void AddEmployees(params Employee[] emps)
        {
            foreach (var e in emps)
            {
                AddEmployee(e);
            }
        }
        public void RemoveEmployee(string id)
        {
            Employee e = GetEmployee(id);
            if (e != null)
            {
                Employees.Remove(e);
                e.Remove();
            }
        }
        public void AddTo(IOrgUnit org)
        {
            Organization = org as Organization;
        }
        public void Remove() 
        {
            Organization = null;
            Id = null;
            foreach (var e in Employees)
            {
                {
                    e.Remove();
                }
            }
            Employees.Clear();
        }

        public Employee GetEmployee(string id)
        {
            return Employees.Find(e => e.Id == id);
        }

        public bool Equals(Department other)
        {
            if (other == null) return false;
            return (Type.Equals(other.Type));
        }
        private bool HasEmployee(Employee emp)
        {
            return Employees.Contains(emp);
        }
        public override string ToString()
        {
            return $"{Name} (id: {Id})";
        }
        public void Show()
        {
            Console.WriteLine(this);
            ShowContacts();
            Console.WriteLine();
            ShowEmployees();
            Console.WriteLine();
        }
        public void ShowContacts()
        {
            Console.WriteLine($"Phone: {Phone}");
        }
        public void ShowEmployees()
        {
            foreach (var e in Employees)
            {
                Console.WriteLine(e);
            }
        }
    }

}
