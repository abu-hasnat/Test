using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Areas.Identity.Data;
using Test.Models;

namespace Test.Controllers
{
    public class EmployersController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly ApplicationDbContext _db;

        public EmployersController(
           UserManager<IdentityUser> userManager,
           IUserStore<IdentityUser> userStore,
           SignInManager<IdentityUser> signInManager,
           ApplicationDbContext db
           )


        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _db = db;

        }

        public IActionResult Profile(string id)
        {
            if (_db.Users.Any(m => m.Id == id))
            {
                var profile = _db.Employers.Find(id);
                if (profile == null)
                {
                    profile = new();
                }
                return View(profile);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Profile(Employer model)
        {
            if (_db.Users.Find(model.Id) == null)
            {
                return NotFound();
            }

            if (_db.Employers.Any(m => m.Id == model.Id))
            {
                _db.Entry(model).State = EntityState.Modified;
            }
            else
            {
                _db.Entry(model).State = EntityState.Added;
            }

            _db.SaveChanges();
            return Redirect("/Identity/Account/Login");


        }
    }
}
