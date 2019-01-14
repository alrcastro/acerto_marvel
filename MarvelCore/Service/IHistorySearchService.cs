using MarvelCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCore.Service
{
    public interface IHistorySearchService
    {
        void AddHistory(User user, string input, DateTime date);
        Task<List<SearchHistory>> GetAllHistory(User user);
        void DeleteHistory(User user, string Id);
    }
}
