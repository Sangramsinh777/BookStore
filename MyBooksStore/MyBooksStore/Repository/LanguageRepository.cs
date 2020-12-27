using Microsoft.EntityFrameworkCore;
using MyBooksStore.Data;
using MyBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreContext _context = null;
        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Languages.Select(l => new LanguageModel()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description
            }).ToListAsync();
        }
    }
}
