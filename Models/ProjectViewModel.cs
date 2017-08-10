using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugProj.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public int? ClientId { get; set; }
        public DateTime? CreateDate { get; set; }

        public int BugCount {get; set;}

    }
}