using PaylocityCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaylocityCodingChallenge.Controllers
{
    public static class PayrollHelper
    {
        private const double EmployeeBenefitCost = 1000;
        private const double DependentBenefitCost = 500;

        public static void AddNewEmployee(Payroll payroll)
        {
            //Make sure the user input a name for the new employee
            if (!String.IsNullOrEmpty(payroll.NewEmployeeName))
            {
                //After validation, add the employee to the payroll
                var newEmployee = new Employee() { Name = payroll.NewEmployeeName.Trim() };

                //Calculate their benefit cost
                if (!String.IsNullOrEmpty(payroll.NewEmployeeName) && FirstLettStartsWithA(payroll.NewEmployeeName.Substring(0, 1)))
                    newEmployee.AnnualBenefitCosts = EmployeeBenefitCost - (EmployeeBenefitCost * .1);

                //Add their listed dependents
                foreach (var dependent in payroll.NewEmployeeDependents)
                {
                    //Calculate the dependents benefit cost
                    if (!String.IsNullOrEmpty(dependent.Name) && FirstLettStartsWithA(dependent.Name.Substring(0, 1)))
                        dependent.AnnualDependentBenfitCost = DependentBenefitCost - (DependentBenefitCost * .1);

                    //Add the dependent
                    newEmployee.Dependents.Add(dependent);
                }

                //Add the new employee
                payroll.EmployeePayroll.Add(newEmployee);
            }


            ClearNewEmployeeData(payroll);
        }

        public static void ClearNewEmployeeData(Payroll payroll)
        {
            payroll.NewEmployeeName = String.Empty;
            payroll.NewEmployeeDependents.Clear();
        }

        public static void CalculateExpenses(Payroll payroll)
        {
            //Calculate the total cost of all benefits for the employees of the company
            payroll.TotalBenefitCosts = 0;

            foreach (var employee in payroll.EmployeePayroll)
            {
                payroll.TotalBenefitCosts += employee.AnnualBenefitCosts;

                //Add their dependents
                foreach (var depend in employee.Dependents)
                {
                    payroll.TotalBenefitCosts += depend.AnnualDependentBenfitCost;
                }
            }
        }

        public static bool FirstLettStartsWithA(string letter)
        {
            return letter.ToUpper().Equals("A");
        }
    }
}
