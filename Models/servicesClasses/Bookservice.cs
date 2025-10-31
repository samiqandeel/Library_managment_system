using library_management_system;
using Library_mangement_system.Models.Ireposatoryinterfases;
using Library_mangement_system.Models.IserviceesInterfasees;

namespace Library_mangement_system.Models.servicesClasses
{
    public class Bookservice : Ibooksevice
    {
        private readonly IbookReposatory _repo;

        public Bookservice(IbookReposatory bookReposatory)
        {
            _repo = bookReposatory;
        }

        public async Task Addbook(Book library)
        {
            await _repo.AddBook(library);
        }

        public async Task<IEnumerable<Book>> GetAllbook()
        {
            return await _repo.GetAllBooks();
        }

        public async Task<Book> GetbookById(int id)
        {
            return await _repo.GetBookById(id);
        }

        public async Task Removebook(int id)
        {
            await _repo.RemoveBook(id);
        }

        public async Task updatbook(Book book)
        {
            await _repo.updatBook(book);
        }
    }
}
