using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using MarvelCore.Helpers;
using MarvelCore.Models;

namespace MarvelCore.Service
{
    public class SearchHistoryService : IHistorySearchService
    {
        FirebaseClient firebase;
        public SearchHistoryService() {

            firebase = new FirebaseClient(Constants.FirebaseURL);
        }
        public async void AddHistory(User user, string input, DateTime date)
        {
            if (user == null)
                return;

            var obj = new SearchHistory { Input = input, SearchDate = date };

            await firebase.Child("searchHistory").Child(user.Id).PostAsync(obj);            
        }

        public async void DeleteHistory(User user, string id)
        {
            if (user == null)
                return;

           await firebase.Child("searchHistory").Child(user.Id).Child(id).DeleteAsync();           
        }

        public async Task<List<SearchHistory>> GetAllHistory(User user)
        {
            var hists = await firebase.Child("searchHistory").Child(user.Id).OnceAsync<SearchHistory>();
            if (hists.Count == 0)
                return new List<SearchHistory>();

            return hists.Select(h => { h.Object.Id = h.Key; return h.Object; }).OrderByDescending(m => m.SearchDate).ToList();
        }
    }
}
