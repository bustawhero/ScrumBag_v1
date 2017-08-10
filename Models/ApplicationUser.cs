using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BugProj.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string MI { get; set; }
        public string Alias { get; set; }
        public string Pic { get; set; }
        public string  UserType { get; set; }
        public int CompanyID { get; set; }

    }
}