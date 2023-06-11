using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using Dapper;
using System.Web.UI;
using System.Text;

namespace WebApplication1.Controllers
{
    public class EmployeeApiController : ApiController
    {
        // GET: api/EmployeeApi
        public IEnumerable<EmployeeAgeRanking> EmployeeAgeList()
        {
            List<EmployeeAgeRanking> employees = new List<EmployeeAgeRanking>();
            var connectionString = ConfigurationManager.ConnectionStrings["WebAppEmployee"].ConnectionString;
            string sqlcommand = "Select Employee_Profiles.Name, Departments.Designation, Employee_Profiles.Age  " +
                "from Departments join Employee_Profiles on Departments.EmpId = Employee_Profiles.EmployeeId\r\nwhere Age in ((select max(Age) from Employee_Profiles), (select min(Age) from Employee_Profiles)) " +
                "order by Age desc";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var result = db.Query(sqlcommand).ToList();
                
                employees = db.Query<EmployeeAgeRanking>(sqlcommand).ToList();
            }
            return employees;
        }

        //// GET: api/EmployeeApi/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/EmployeeApi
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/EmployeeApi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/EmployeeApi/5
        //public void Delete(int id)
        //{
        //}
    }
}
