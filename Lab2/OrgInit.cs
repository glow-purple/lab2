using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2
{
    static public class OrgInit
    {
        static public List<string> FirstNames = new List<string> { "Florence", " George", "Ann", "Erin", "Mark" };
        static public List<string> LastNames = new List<string> { "Cat", " Racoon", "Squirrel", "Weasel", "Hamster" };
        static public List<string> Positions = new List<string> { "manager", "employee", "secretary", "accountant", "observer" };
        static public List<string> Streets = new List<string> { "First St.", "Second St.", "Third St." };
        static private Random rand = new Random();

        static public Employee GetRandEmployee()
        {
            FullName name = new FullName(FirstNames[rand.Next(FirstNames.Count)], LastNames[rand.Next(LastNames.Count)]);
            Employee randEmp = new Employee(name, GetRandDateTime(), GetRandTitle());
            return randEmp;
        }
        static public DateTime GetRandDateTime()
        {
            DateTime randDate = new DateTime(rand.Next(1800, 1890), rand.Next(1, 12), rand.Next(1, 30));
            return randDate;
        }
        static public Address GetRandAddress()
        {
            Address randAddress = new Address("Chicago", Streets[rand.Next(Streets.Count)], rand.Next(100));
            return randAddress;
        }
        static public string GetRandTitle()
        {
            return Positions[rand.Next(Positions.Count)];
        }
        static public PhoneNumber GetRandPhone()
        {
            PhoneNumber randPhone = new PhoneNumber(9, rand.Next(10000, 99999));
            return randPhone;
        }
        static public void InitializeOrganization(Organization test)
        {
            test.Address = GetRandAddress();
            test.Phone = GetRandPhone();
            test.AddDepartments(new Department(DepartmentType.Marketing, GetRandPhone()),
                        new Department(DepartmentType.Production, GetRandPhone()),
                        new Department(DepartmentType.Research, GetRandPhone()));
            test.AddEmployee("M", GetRandEmployee());
            test.AddEmployees("P", GetRandEmployee(), GetRandEmployee());
            test.AddEmployees("R", GetRandEmployee(), GetRandEmployee());
        }
    }
}
