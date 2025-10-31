using library_management_system;
using Library_mangement_system.Models.Ireposatoryinterfases;
using Microsoft.EntityFrameworkCore;

namespace Library_mangement_system.Models.ReposetoryClasses
{
    public class bookReposatory : IbookReposatory
    {
        private readonly AppDbContext _context;

        public bookReposatory(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.Include(p => p.Library).ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
            if (book == null)
                throw new InvalidOperationException("this is book not found!");
            else 
            return await _context.Books.Include(p => p.Library).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task RemoveBook(int id)
        {
            var book = await GetBookById(id);
            if (book != null)
                _context.Books.Remove(book);

              await _context.SaveChangesAsync();

        }
        public async Task updatBook(Book book)
        {
           
            if (book != null)
                _context.Books.Update(book);

               await _context.SaveChangesAsync();
        }
    }
}
