using library_management_system.serviceesInterfasees;
using Library_mangement_system.Models.Entitys;
using Library_mangement_system.Models.IserviceesInterfasees;
using Library_mangement_system.Models.servicesClasses;
using Library_mangement_system.viewmodel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library_mangement_system.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinmanager;
        private readonly ILibraryService _libraryservice;
        private readonly Icartservice  _cartservice;


        public AccountController(UserManager<ApplicationUser> usermanager
                               , SignInManager<ApplicationUser> signinmanager
                               , ILibraryService libraryservice
                               , Icartservice cartservice)
        {
            _usermanager = usermanager;
            _libraryservice = libraryservice;
            _signinmanager = signinmanager;
            _cartservice = cartservice;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var libraris = await _libraryservice.GetAllLibrary();
            ViewData["Address"] = new SelectList(libraris, "Id", "Address");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel userviewmodel)
        {
            //mapping
            ApplicationUser usermodel = new ApplicationUser();

            usermodel.Email = userviewmodel.Email;
            usermodel.UserName = userviewmodel.Name;
            usermodel.PasswordHash = userviewmodel.Password;
            usermodel.Libraryid = userviewmodel.Address;

            if (ModelState.IsValid)
            {
                //save on db
                IdentityResult result = await _usermanager.CreateAsync(usermodel, userviewmodel.Password);
                //Created cookies
                if (result.Succeeded)
                {
                    await _signinmanager.SignInAsync(usermodel, false);

                    // take Addition data on Claims 
                    List<Claim> Claims = new List<Claim>
                        {
                            new Claim ("ClaimAddress" , usermodel.Libraryid.ToString())
                        };
                    await _signinmanager.SignInWithClaimsAsync(usermodel,false, Claims);

                    return RedirectToAction("Exist_Book", "Library", new { id = usermodel.Libraryid });
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            var libraris = await _libraryservice.GetAllLibrary();
            ViewData["Address"] = new SelectList(libraris, "Id", "Address");

            return View("Register", userviewmodel);
        }

        public async Task<IActionResult> signout()
        {
            var userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userid == null)
                throw new Exception("You not login");
            _cartservice.ClearCart(userid);

            await _signinmanager.SignOutAsync();
            return View("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel userviewmodel)
        {
            //check Found
            // check data is valid from user with validatioin on Login user view model or No 
            if (ModelState.IsValid)
            {
                //fined object => this is row by contain name  
                ApplicationUser appuser = await _usermanager.FindByNameAsync(userviewmodel.Name);

                if (appuser !=null)
                {
                    //check the password input with user Equel password in object the selected with name  
                    bool found = await _usermanager.CheckPasswordAsync(appuser, userviewmodel.Password);

                    if (found)
                    {
                        //create Cooke
                        // take otomatic data Only
                        await _signinmanager.SignInAsync(appuser, userviewmodel.Rememberme);

                        // take Addition data on Claims 
                        List<Claim> Claims = new List<Claim>
                        {
                            new Claim ("ClaimAddress" , appuser.Libraryid.ToString())
                        };
                        await _signinmanager.SignInWithClaimsAsync(appuser, userviewmodel.Rememberme, Claims);

                        return RedirectToAction("index", "Books");
                    }
                }
                ModelState.AddModelError("", "The Name or password Worring");
            }
            return View("Login", userviewmodel);
        }

    }
}

