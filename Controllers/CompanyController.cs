using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BugProj.Models;
using BugProj.Data;
using BugProj.Repositories;


namespace BugProj.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private BugProjContext db;
        private DataRepo dr;

        public CompanyController(BugProjContext _db)
        {
            this.db = _db;
            this.dr = new DataRepo( db);
        }

        [HttpGet("[action]")]
        public IActionResult GetCompanyData()
        {
           var company = dr.GetCompany(1);

           return Json(company);
        }

        [HttpGet("[action]")]
        public IActionResult GetClientData()
        {
            var clients = dr.GetClientData(1);

            return Json(clients);
        }

        [HttpGet("[action]")]
        public IActionResult GetProjData(int clientid)
        {
            var clients = dr.GetProjectData(clientid);

            return Json(clients);
        }

        [HttpGet("[action]")]
        public IActionResult GetBugList(int projid)
        {
           var bugs = dr.GetListofBugs(projid);

           return Json(bugs);
        }

        [HttpPost("[action]")]
        public IActionResult UpdateCompany([FromBody]Company comp)
        {
            dr.UpdateCompanyData(comp);

            return Json("success");
        }

        [HttpGet("[action]")]
        public IActionResult GetBugData(int bugid)
        {
            var bug = dr.GetBugData(bugid);

            return Json(bug);
        }
        //GetProjectTasks
        [HttpGet("[action]")]
        public IActionResult GetBugTasks(int bugid)
        {
            var bugtasks = dr.GetProjectTasks(bugid);

            return Json(bugtasks);
        }
    }

}