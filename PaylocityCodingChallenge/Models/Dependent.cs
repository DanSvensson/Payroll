using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaylocityCodingChallenge.Models
{
    public class Dependent
    {
        public Dependent()
        {
            AnnualDependentBenfitCost = 500;
        }

        public string Name { get; set; }

        public double AnnualDependentBenfitCost { get; set; }
    }
}