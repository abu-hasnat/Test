using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.Areas.Identity.Data;
using Test.Models;

namespace Test.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public JobsController(ApplicationDbContext db, UserManager<IdentityUser> userManager) 
        {
            _db = db;
            _userManager = userManager;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Job job)
        {
            if(ModelState.IsValid)
            {
                job.EmployerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _db.Add(job);
                _db.SaveChanges();
            }
            return View(job);
        }
    }
}
