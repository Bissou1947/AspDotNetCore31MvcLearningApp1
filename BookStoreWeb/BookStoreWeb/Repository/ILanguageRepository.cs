using BookStoreWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreWeb.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageVM>> GetLanguages();
    }
}