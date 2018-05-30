using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class Auditor
    {
        public static int CountDepartments(Organization org)
        {
            return org.Departments.Count();
        }
        public static int CountEmployees(Department dep)
        {
            return dep.Employees.Count();
        }
        public static int CountEmployees(Organization org)
        {
            int total = 0;
            foreach (var d in org.Departments)
            {
                total += d.Employees.Count();
            }
            return total;
        }
        public static double GetAverageSalary(Department dep)
        {
            double total = 0;
            foreach (var e in dep.Employees)
            {
                total += e.CurrentSalary.Sum;
            }
            return total / dep.Employees.Count();
        }
    }
}
