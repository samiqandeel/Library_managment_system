using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Library_mangement_system.Models;
using Library_mangement_system.Models.Entitys; // for ApplicationUser

namespace Library_mangement_system.Controllers
{
        public class LibrianController : Controller
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public LibrianController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }

            // Get all users with the Librarian role
            [HttpGet]
            public async Task<IActionResult> GetAllLibrian()
            {
                var users = _userManager.Users.ToList();
                var librarians = new List<ApplicationUser>();

                foreach (var user in users)
                {
                    if (await _userManager.IsInRoleAsync(user, "Librian"))
                    {
                        librarians.Add(user);
                    }
                }

                return View(librarians);
            }


           // Remove Librarian role from a user
            [HttpPost]
            public async Task<IActionResult> RemoveLibrian(string Id)
            {
                var users = _userManager.Users.ToList();
                var user = users.FirstOrDefault(u => u.Id == Id);
                if (user == null)
                    return NotFound();
                
                await _userManager.RemoveFromRoleAsync(user, "Librian");
                return RedirectToAction(nameof(GetAllLibrian));
                
                //var user = await _userManager.FindByIdAsync(Id);
                //if (user == null)
                //    return NotFound();
                
                //await _userManager.RemoveFromRoleAsync(user, "Librian");
                //return RedirectToAction(nameof(GetAllLibrian));
                
                //===================================
            }
        }
}


