using library_management_system;

namespace Library_mangement_system.Models.IserviceesInterfasees
{
    public interface Ibooksevice
    {
        public Task Addbook(Book library);
        public Task<IEnumerable<Book>> GetAllbook();
        public Task<Book> GetbookById(int id);
        public Task Removebook(int id);
        public Task updatbook(Book book);
    }
}
