using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Applicant
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual IdentityUser User { get; set; }
        [Required(ErrorMessage = "Please enter your personal name")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Please enter a personal name between 3-200 characters")]
        public string PersonalName { get; set; }
        [Required(ErrorMessage = "Please enter your family name")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Please enter a faily name between 3-200 characters")]
        public string FamilyName { get; set; }
        [Required(ErrorMessage = "Please enter your date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please select a region")]
        public string Region { get; set; }
        public string IndustryAreas { get; set; }
    }
}
