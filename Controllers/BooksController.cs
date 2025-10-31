using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using library_management_system;
using Library_mangement_system.Models.IserviceesInterfasees;
using library_management_system.serviceesInterfasees;
using Library_mangement_system.filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Library_mangement_system.Controllers
{
    public class BooksController : Controller
    {
        private readonly Ibooksevice _bookservice;
        private readonly ILibraryService _libraryservice;

        public BooksController(Ibooksevice bookservice , ILibraryService libraryservice)
        {
            _bookservice = bookservice;
            _libraryservice = libraryservice;
        }

        // GET: Books
        
        [HandelErrorException]
        public async Task<IActionResult> Index()
        {
            // throw new Exception("Errorrrrrrrrrrrr!");

            var books = await _bookservice.GetAllbook();
            return  View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        { 
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookservice.GetbookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public async Task<IActionResult> Add()
        {
            var libraris = await _libraryservice.GetAllLibrary();
            ViewData["LibraryId"] = new SelectList(libraris, "Id", "Address");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Book book)
        {
            var errorList = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            

            if (ModelState.IsValid)
            {
                await _bookservice.Addbook(book);
                return RedirectToAction(nameof(Index));
            }

            var libraris = await _libraryservice.GetAllLibrary();

            ViewData["LibraryId"] = new SelectList(libraris, "Id", "Address", book.LibraryId);
            return View(book);
        }

        [Authorize (Roles = "owner , Librian")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookservice.GetbookById(id);
            if (book == null)
            {
                return NotFound();
            }
            var library = await _libraryservice.GetAllLibrary();
            ViewData["LibraryId"] = new SelectList(library, "Id", "Address", book.LibraryId);
            return View(book);
        }

        [Authorize(Roles = "owner , Librian")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookservice.updatbook(book);
                return RedirectToAction("Details" , new { id = book.Id});
            }

            var library = await _libraryservice.GetAllLibrary();
            ViewData["LibraryId"] = new SelectList(library , "Id", "Address", book.LibraryId);
            return View(book);
        }

        [Authorize(Roles = "owner , Librian")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookservice.GetbookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [Authorize(Roles = "owner , Librian")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _bookservice.GetbookById(id);
            
               await _bookservice.Removebook(id);
               return RedirectToAction(nameof(Index));

            
        }

    }
}
