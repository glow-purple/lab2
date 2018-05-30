using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab2
{
    static public class OrgDemo
    {
        static public bool ContainsOnlyLetters(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        static public string InputDepartmentId()
        {
            Console.WriteLine("Choose department");
            string id = Console.ReadLine();
            return id;
        }
        static public string InputEmployeeId()
        {
            Console.WriteLine("Choose employee");
            string id = Console.ReadLine();
            return id;
        }
        static public Employee InputNewEmployee()
        {
            bool isValid = false;
            Console.WriteLine("Choose department");
            string depId = Console.ReadLine();
            string firstName = null;
            string lastName = null;
            while (!isValid)
            {
                Console.WriteLine("First Name:");
                firstName = Console.ReadLine();
                Console.WriteLine("Last Name:");
                lastName = Console.ReadLine();
                if ((ContainsOnlyLetters(firstName)) && (ContainsOnlyLetters(lastName)))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("invalid name");
                }
            }
            Console.WriteLine("Date of birth:");
            DateTime dateOfBirth;
            while (!(DateTime.TryParse(Console.ReadLine(), out dateOfBirth)))
            {
                Console.WriteLine("invalid date");
            }
            Console.WriteLine("Position:");
            string position = Console.ReadLine();
            Employee e = new Employee(new FullName(firstName, lastName), dateOfBirth, position);
            return e;
        }
        static public void CallMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 add a new department\n2 add employees\n3 show info\n" +
                "4 remove employees\n5 remove departments\n6 new employee\n" +
                "7 move to another department\n8 show average salary by department\n9 esc");
        }
        static public void TestOrganization(Organization org)
        {
            char option;
            bool exit = false;
            do
            {
                CallMenu();
                Char.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case '1':
                        Console.WriteLine("Department to add: research, production, sales, accounting, HR, marketing");
                        org.AddDepartment(new Department((DepartmentType)Enum.Parse(typeof(DepartmentType), Console.ReadLine(), true)));
                        break;
                    case '2':
                        Employee emp = OrgInit.GetRandEmployee();
                        org.AddEmployees(InputDepartmentId(), emp);
                        break;
                    case '3':
                        org.ShowInfo();
                        break;
                    case '4':
                        org.RemoveEmployee(InputDepartmentId(), InputEmployeeId());
                        break;
                    case '5':
                        org.RemoveDepartment(InputDepartmentId());
                        break;
                    case '6':
                        org.AddEmployee(InputDepartmentId(), InputNewEmployee());
                        break;
                    case '7':
                        org.MoveEmployee(InputDepartmentId(), InputEmployeeId(), InputDepartmentId());
                        break;
                    case '8':
                        Console.WriteLine($"Company has {Auditor.CountEmployees(org)} employees in {Auditor.CountDepartments(org)} departments");
                        Console.WriteLine("Average salary by department:");
                        foreach (var d in org.Departments)
                        {
                            Console.WriteLine($"{d.Type} {Auditor.GetAverageSalary(d):c}");
                        }
                        break;
                    case '9':
                        exit = true;
                        break;
                }
            } while (!exit);
        }
    }
}
