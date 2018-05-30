using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Organization : IOrgUnit
    {
        public string Name { get; set; }
        public List<Department> Departments { get; private set; }
        public Address Address { get; set; }
        public PhoneNumber Phone { get; set; }

        public Organization(string name) : this(name, new Address(), new PhoneNumber())
        {
            Name = name;
        }
        public Organization(string name, Address address, PhoneNumber phone, params Department[] departments)
        {
            Name = name;
            Departments = new List<Department>();
            Address = address;
            Phone = phone;
            foreach (var d in departments)
            {
                if (!(HasDepartment(d)))
                {
                    Departments.Add(d);
                }
            }
        }

        public void AddDepartment(Department dep)
        {
            if (dep != null && !(HasDepartment(dep)))
            {
                Departments.Add(dep);
                dep.AddTo(this);
            }
        }
        public void AddDepartments(params Department[] deps)
        {
            foreach (var d in deps)
            {
                AddDepartment(d);
            }
        }

        public void AddEmployee(string id, Employee e)
        {
            {
                Department dep = GetDepartment(id);
                if (dep != null)
                {
                    dep.AddEmployee(e);
                }
            }
        }
        public void AddEmployees(string id, params Employee[] emps)
        {
            {
                Department dep = GetDepartment(id);
                foreach (var e in emps)
                {
                    AddEmployee(id, e);
                }
            }
        }

        public void RemoveDepartment(string id)
        {
            Department dep = GetDepartment(id);
            if (dep != null)
            {
                Departments.Remove(dep);
                dep.Remove();
            }
        }
        public void RemoveEmployee(string depId, string empId)
        {
            Department dep = GetDepartment(depId);
            if (dep != null)
            {
                dep.RemoveEmployee(empId);
            }
        }
        public void MoveEmployee(string fromDepId, string empId, string toDepId)
        {
            Department fromDep = GetDepartment(fromDepId);
            Department toDep = GetDepartment(toDepId);
            if (!(fromDep == null || toDep == null))
            {
                Employee e = fromDep.GetEmployee(empId);
                if (e != null)
                {
                    fromDep.RemoveEmployee(empId);
                    toDep.AddEmployee(e);
                }
            }
        }

        public Department GetDepartment(string id)
        {
            Department result = Departments.Find(e => e.Id == id);
            return result;
        }
        private bool HasDepartment(Department dep)
        {
            return Departments.Contains(dep);
        }
        public override string ToString()
        {
            return $"\"{Name}\" (Address: {Address}, {Phone})";
        }

        public void ShowInfo()
        {
            Console.WriteLine(this);
            Console.WriteLine();
            ShowDepartments();
        }
        public void ShowDepartments()
        {
            foreach (var d in Departments)
            {
                d.Show();
                Console.WriteLine();
            }
        }
    }
}
