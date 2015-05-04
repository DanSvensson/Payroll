using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PaylocityCodingChallenge.Models
{
    public class Employee
    {
        public Employee()
        {
            Dependents = new List<Dependent>();
            AnnualBenefitCosts = 1000;
        }

        public string Name { get; set; }

        public List<Dependent> Dependents { get; set; }

        public double AnnualBenefitCosts { get; set; }
    }
}