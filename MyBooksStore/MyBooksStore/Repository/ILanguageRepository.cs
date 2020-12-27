using MyBooksStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}