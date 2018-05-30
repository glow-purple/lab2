using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Organization test = new Organization("J");
            OrgInit.InitializeOrganization(test);
            OrgDemo.TestOrganization(test);
        }
    }
}
