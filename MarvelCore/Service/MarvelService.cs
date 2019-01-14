using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MarvelCore.Models;
using Newtonsoft.Json;

namespace MarvelCore.Service
{
    public class MarvelService : IMarvelService
    {
        private const string API_KEY = "";

        private string BaseUrl = "https://gateway.marvel.com/v1/public/characters";

        public string UrlCharacters { get {
                return string.Format("{0}?apiKey={1}", BaseUrl, API_KEY);
            } }

        public async Task<List<MarvelHero>> SearchHeroes(string name, int page)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(UrlCharacters)).Result;

                if (response != null) {
                    
                    var obj = JsonConvert.DeserializeObject<MarvelResponse>(response);
                    return obj.Data.Results;

                }
                return new List<MarvelHero>();
            }
        }
    }
}
