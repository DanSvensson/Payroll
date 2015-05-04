using PaylocityCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaylocityCodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Payroll());
        }

        [HttpPost]
        public ActionResult Index([Bind] Payroll payroll)
        {
            //Check the incoming fields and add the new employee and their dependents
            PayrollHelper.AddNewEmployee(payroll);
                
            //Recalculate the expenses for the payroll
            PayrollHelper.CalculateExpenses(payroll);

           //Return to the view with updated information
           return View(payroll);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AddDependent()
        {
            return View(new List<Dependent>() { new Dependent() });
        }
    }
}