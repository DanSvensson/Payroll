using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaylocityCodingChallenge.Models
{
    public class Payroll
    {
        public double TotalBenefitCosts { get; set; }

        public String NewEmployeeName { get; set; }

        public List<Dependent> NewEmployeeDependents { get; set; }
        
        public List<Employee> EmployeePayroll { get; set; }

        public Payroll()
        {
            NewEmployeeDependents = new List<Dependent>();

            EmployeePayroll = new List<Employee>();
        }
    }
}