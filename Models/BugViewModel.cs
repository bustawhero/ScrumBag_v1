using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugProj.Models
{
    public class BugViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BugStatus { get; set; }
        public string ProjType { get; set; }
        public bool? BackLog { get; set; }
        public int OpenTaskCount { get; set;}

        //public DateTime? DueDate { get; set; }

    }
}