using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LogisticsWebsite_WebProgramingProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string CountryRegion { get; set; }
    }
}
