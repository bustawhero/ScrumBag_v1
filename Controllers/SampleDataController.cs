using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugProj.Data;
using BugProj.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace BugProj.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bruising", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private BugProjContext _db;
        private DataRepo  _repo;

        public SampleDataController(BugProjContext db)
        {
            _db = db;
            _repo = new DataRepo(_db);
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<ProjTasks> GetTasksbyClient()
        {
            try{

            var rng = _repo.GetProjectClientTask(2);
            return rng;
                
            }
            catch(Exception e)
            {
                string mess = e.Message;
                string s = mess;
                return null;
            }

        }

        [HttpGet("[action]")]
        public IActionResult GetProjectTasks()
        {
           var bug = _repo.GetProjectTasks(1);
           
            return Json(bug);
        }

        [HttpGet("[action]")]
        public IActionResult GetBugData()
        {
           var bug = _repo.GetBugData(1);
           
            return Json(bug);
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
