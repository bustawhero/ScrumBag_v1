using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugProj.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        [Display(Name = "Middle Initial")]
        [StringLength(1, MinimumLength =1)]
        public string MI { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4)]
        public string Alias { get; set; }

        [Required]
        public string UserType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Company not Selected")]
        public int CompanyID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Pic { get; set; }

    }


    public enum UseType
    {
        Developer,
        Tester,
        SystemsAnalyst,
        Analyst,
        Manager
    }
}