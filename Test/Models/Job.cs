using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string CompetitionNumber {  get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string IndustryArea { get; set; }
        public DateTime Date { get; set; }
        public DateTime SubmissionDate { get; set; }
        [Required]
        public string EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
