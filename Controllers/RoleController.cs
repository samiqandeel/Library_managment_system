using library_management_system.serviceesInterfasees;
using Library_mangement_system.Models.Entitys;
using Library_mangement_system.viewmodel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Library_mangement_system.Controllers
{
    [Authorize (Roles ="owner")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signmanager;
        private readonly ILibraryService _libraryservice;

        public RoleController(RoleManager<IdentityRole> rolemanager ,
                              UserManager<ApplicationUser> usermanager ,
                              SignInManager<ApplicationUser> signmanager ,
                              ILibraryService libraryservice)
        {
            _rolemanager = rolemanager;
            _usermanager = usermanager;
            _signmanager = signmanager;
            _libraryservice = libraryservice;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleviewmodel)
        {
            if(ModelState.IsValid)
            {

                //mapping
                IdentityRole role = new IdentityRole();
                role.Name = roleviewmodel.RoleName;

                //save in db
                IdentityResult result = await _rolemanager.CreateAsync(role);

                if (result.Succeeded == true)
                {
                    return View("AddRole");
                }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
               
            }
            return View(roleviewmodel);
        }
        [HttpGet]
        public async Task<IActionResult> Registerwithowner()
        {
            var libraris = await _libraryservice.GetAllLibrary();
            ViewData["Address"] = new SelectList(libraris, "Id", "Address");
            return View();
        }
        [HttpPost]
       // [Authorize = AddRole("owner")]
        public async Task<IActionResult> Registerwithowner(RegisterUserViewModel userviewmodel)
        {
            if (ModelState .IsValid )
            {
                //mappping
                ApplicationUser appuser = new ApplicationUser();
                appuser.UserName = userviewmodel.Name;
                appuser.Email = userviewmodel.Email ;
                appuser.PasswordHash  = userviewmodel.Password ;
                appuser.Libraryid  = userviewmodel.Address  ;
                

                //save in db 
                IdentityResult result = await  _usermanager.CreateAsync(appuser, userviewmodel.Password);
                if (result.Succeeded)
                {
                    //assign to role
                    await _usermanager.AddToRoleAsync(appuser, "owner");
                    
                    //create cookies
                    await _signmanager.SignInAsync(appuser, false);
                    return RedirectToAction("Index", "Books");
                }
                else
                {
                    foreach (var error in result.Errors )
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            var libraris = await _libraryservice.GetAllLibrary();
            ViewData["Address"] = new SelectList(libraris, "Id", "Address");
            return View(userviewmodel);
        }

         [HttpGet]
        public async Task<IActionResult> RegisterwithLibrian()
        {
            var libraris = await _libraryservice.GetAllLibrary();
            ViewData["Address"] = new SelectList(libraris, "Id", "Address");
            return View();
        }
        [HttpPost]
       // [Authorize = AddRole("owner")]
        public async Task<IActionResult> RegisterwithLibrian(RegisterUserViewModel userviewmodel)
        {
            if (ModelState .IsValid )
            {
                //mappping
                ApplicationUser appuser = new ApplicationUser();
                appuser.UserName = userviewmodel.Name;
                appuser.Email = userviewmodel.Email ;
                appuser.PasswordHash  = userviewmodel.Password ;
                appuser.Libraryid  = userviewmodel.Address  ;
                

                //save in db 
                IdentityResult result = await  _usermanager.CreateAsync(appuser, userviewmodel.Password);
                if (result.Succeeded)
                {
                    //assign to role
                    await _usermanager.AddToRoleAsync(appuser, "Librian");
                    
                    //create cookies
                    //await _signmanager.SignInAsync(appuser, false);
                    return RedirectToAction("Index", "Books");
                }
                else
                {
                    foreach (var error in result.Errors )
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            var libraris = await _libraryservice.GetAllLibrary();
            ViewData["Address"] = new SelectList(libraris, "Id", "Address");
            return View(userviewmodel);
        }
    }

}
