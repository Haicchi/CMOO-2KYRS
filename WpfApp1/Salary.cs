using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Salary
    {
        public int WorkerId { get; set; }
        public double SalaryForFirstHalf { get; set; }
        public double SalaryForSecondHalf { get; set; }

        public Salary() { }
        public Salary(int workerId, double salaryForFirstHalf, double salaryForSecondHalf)
        {
            WorkerId = workerId;
            SalaryForFirstHalf = salaryForFirstHalf;
            SalaryForSecondHalf = salaryForSecondHalf;
        }
        override public string ToString()
        {
            return $"{WorkerId}, {SalaryForFirstHalf}, {SalaryForSecondHalf}";
        }
    }
}
