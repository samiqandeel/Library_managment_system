using library_management_system.Ireposatoryinterfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system.ReposetoryClasses
{
    public class LIibraryReposatory : ILIibraryReposatory
    {
        private AppDbContext _context;

        public LIibraryReposatory(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task AddLibrary(Library  library)
        {
            _context.Libraries.Add(library);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Library>> GetAllLibrary()
        {
             return await _context.Libraries.ToListAsync();
        }

        public async Task<Library> GetLibraryById(int id)
        {
            var library = await _context.Libraries.FirstOrDefaultAsync(p => p.Id == id);
            if (library == null)
                throw new InvalidOperationException("this is book not found!");
            else
                return await _context.Libraries.FindAsync(id);
        }
        public async Task RemoveLibrary(int id)
        {
            var library =  await GetLibraryById(id);
            if (library != null)
                 _context.Libraries.Remove(library);

            await _context.SaveChangesAsync();
        }
        public async Task updataLibrary(Library library)
        {
            _context.Libraries.Update(library);
            await _context.SaveChangesAsync();

        }
    }
}
