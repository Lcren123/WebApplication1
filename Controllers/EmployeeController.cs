using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult EmployeeList()
        {
            EmployeeApiController empApiController = new EmployeeApiController();
            List<EmployeeAgeRanking> employees = new List<EmployeeAgeRanking>();
            employees = empApiController.EmployeeAgeList().ToList();

            return View(employees);
        }

        public ActionResult OpenTextFile()
        {
            return View();
        }
    }
}