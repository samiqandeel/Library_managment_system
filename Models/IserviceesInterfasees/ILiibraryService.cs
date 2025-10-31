using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system.serviceesInterfasees
{
    public interface ILibraryService
    {
        public Task AddLibrary(Library library);
        public Task<IEnumerable<Library>> GetAllLibrary();
        public Task<Library> GetLibraryById(int id);
        public Task RemoveLibrary(int id);
        public Task updataLibrary(Library library);
    }
}
