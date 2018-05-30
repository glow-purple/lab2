using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
     public class Salary
    {
        public double Sum { get; private set; }
        private static Random rand = new Random();
        public Salary()
        {
            Sum = rand.Next(10000);
        }
        public void IncreaseBy(double percent)
        {
            Sum += Sum * (0.01 * percent);
        }
        public void DecreaseBy(double percent)
        {
            Sum -= Sum * (0.01 * percent);
        }
        public void CalculateSalary()
        {
            Sum = rand.Next(10000);
        }
        public override string ToString()
        {
            return $"{Sum:c}";
        }
    }
}