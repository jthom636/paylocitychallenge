using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsWorker
{
    public class Calculator
    {
        public List<double> CalculatePaycheck(Employee employee, int month)
        {
            double benefitsCost = employee.Salary > 80000 ? ((4 / 100) * employee.Salary) / 12 : 0;
            double baseCharge = 1000 + benefitsCost;
            double monthlySalary = employee.Salary / 12;
            double monthlyDependentCost = 0;
            List<double> paychecks = new List<double>();
            foreach (Dependent dependent in employee.Dependents)
            {
                monthlyDependentCost += dependent.Age > 50 ? 800 : 600;
            }
            if (month == 3 || month == 12)
            {
                double checkChargeSpecial = (baseCharge + monthlyDependentCost) / 3;
                double checkSalarySpecial = monthlySalary / 3;
                paychecks.Add(checkSalarySpecial - checkChargeSpecial);
                paychecks.Add(checkSalarySpecial - checkChargeSpecial);
                paychecks.Add(checkSalarySpecial - checkChargeSpecial);
                return paychecks;
            }

            double checkCharge = (baseCharge + monthlyDependentCost) / 2;
            double checkSalary = monthlySalary / 2;
            paychecks.Add(checkSalary - checkCharge);
            paychecks.Add(checkSalary - checkCharge);
            return paychecks;
        }
    }
}
