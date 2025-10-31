using library_management_system;
using library_management_system.Ireposatoryinterfases;
using library_management_system.serviceesInterfasees;

namespace Library_mangement_system.Models.servicesClasses
{
    public class LibraryService : ILibraryService // model BL
    {
        private readonly ILIibraryReposatory _repo;

        public LibraryService(ILIibraryReposatory repo)
        {
            _repo = repo;
        }

        public async Task AddLibrary(Library library)
        {
            await _repo.AddLibrary(library);
        }

        public async Task<IEnumerable<Library>> GetAllLibrary()
        {
            return await _repo.GetAllLibrary();
        }

        public async Task<Library> GetLibraryById(int id)
        {
            return await _repo.GetLibraryById(id);  
        }

        public async Task RemoveLibrary(int id)
        {
             await _repo.RemoveLibrary(id); 
        }


        public async Task updataLibrary(Library library)
        {
            await _repo.updataLibrary(library);
        }
    }
}
