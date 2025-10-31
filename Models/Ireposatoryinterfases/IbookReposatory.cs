using library_management_system;

namespace Library_mangement_system.Models.Ireposatoryinterfases
{
    public interface IbookReposatory
    {
        public Task AddBook(Book book);
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book> GetBookById(int id);
        public Task RemoveBook(int id);
        public Task updatBook(Book book);
    }
}
