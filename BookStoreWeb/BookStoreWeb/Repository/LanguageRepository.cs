using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWeb.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreWebContext _db = null;
        public LanguageRepository(BookStoreWebContext db)
        {
            _db = db;
        }
        public async Task<List<LanguageVM>> GetLanguages()
        {
            return await _db.Languages.Select(a => new LanguageVM
            {
                id = a.id,
                description = a.description,
                name = a.name,
            }).ToListAsync();
        }
    }
}
