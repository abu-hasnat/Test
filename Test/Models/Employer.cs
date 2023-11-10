using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Employer
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual IdentityUser User { get; set; }
        [Required(ErrorMessage = "Please enter your company name")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Please enter a company name between 3 - 200 character")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter company description")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Please enter a description between 3 - 500 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select a region")]
        public string Region { get; set; }
        public string IndustryAreas { get; set; }
    }
}
