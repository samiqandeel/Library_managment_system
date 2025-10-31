using library_management_system;
using Microsoft.EntityFrameworkCore;

namespace Library_mangement_system.Models
{
    public class SeedData
    {
        private readonly AppDbContext _context;

        public SeedData(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedLibrayrs()
        {
            if (_context.Libraries.Any())
                return;

            List<Library> Librarys = new List<Library>
            {
                new Library{Name = "El Andls" , Address = "Cairo"},
                new Library{Name = "El Andls" , Address = "Alex"},
                new Library{Name = "El Andls" , Address = "Elgarbia"},
                new Library{Name = "El Andls" , Address = "Eloqsr"}
            };

            _context.Libraries.AddRange(Librarys);
            await _context.SaveChangesAsync();
        }

        //public async Task SeedBooks()
        //{
        //    if (_context.Books.Any())
        //        return;

        //    List<Book> Librarys = new List<Book>
        //    {
        //        new Book{LibraryId = 3 , Title = "C#"                , Author = "JAc"    , Year = 1980, url_image = "image1.jpg"  , IsAvailable  = true},
        //        new Book{LibraryId = 3 , Title = "Asp.Net"           , Author = "Nevis"  , Year = 1980, url_image = "image2.jpg"  , IsAvailable  = true},
        //        new Book{LibraryId = 2 , Title = "Clean Archtecture" , Author = "mary"   , Year = 1980, url_image = "image3.jpg"  , IsAvailable  = true},
        //        new Book{LibraryId = 2 , Title = "Data base"         , Author = "john"   , Year = 1980, url_image = "image4.jpg"  , IsAvailable  = true},
        //        new Book{LibraryId = 2 , Title = "Linq"              , Author = "sami"   , Year = 1980, url_image = "image5.jpg"  , IsAvailable  = true},
        //    };

        //    _context.Books.AddRange(Librarys);
        //    await _context.SaveChangesAsync();
        //}


    }
}
