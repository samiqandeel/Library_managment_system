using library_management_system;
using library_management_system.serviceesInterfasees;
using Library_mangement_system.Models.IserviceesInterfasees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library_mangement_system.Controllers
{
    [Authorize (Roles = "owner , Librian")]
    public class LibraryController : Controller
    {
            private readonly ILibraryService _libraryService;
            private readonly Ibooksevice  _bookservice;

        public LibraryController(ILibraryService libraryService, Ibooksevice bookservice)
        {
            _libraryService = libraryService;
            _bookservice = bookservice;
        }

        public async Task<IActionResult> Index()
           {
                var library = await _libraryService.GetAllLibrary();
                return View(library);
           }

            public async Task<IActionResult> Details(int id)
            {
                var library = await _libraryService.GetLibraryById(id);
                if (library == null)
                {
                    return NotFound();
                }
                return View(library);
            }
            
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Library library)
            {
                if (ModelState.IsValid)
                {
                   await _libraryService.AddLibrary(library); 
                    return RedirectToAction(nameof(Index));
                }
                return View(library);
            }

            public async Task<IActionResult> Edit(int id)
            {
                var library = await _libraryService.GetLibraryById(id);
                if (library == null)
                {
                    return NotFound();
                }
                return View(library);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(Library library)
            {
                if (ModelState.IsValid)
                {
                   await _libraryService.updataLibrary(library);
                    return RedirectToAction(nameof(Index));
                }
                return View(library);
            }

            public async Task<IActionResult> Delete(int id)
            {
                var library = await _libraryService.GetLibraryById(id);
                if (library == null)
                {
                    return NotFound();
                }
                return View(library);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await  _libraryService.RemoveLibrary(id);
                return RedirectToAction(nameof(Index));
            }

        [AllowAnonymous]
        public async Task<IActionResult> Exist_Book(int id)
        {
            var books = await _bookservice.GetAllbook();
            var filteredBooks = books.Where(b => b.LibraryId == id).ToList();

            return View(filteredBooks);
        }

    }

   
}
