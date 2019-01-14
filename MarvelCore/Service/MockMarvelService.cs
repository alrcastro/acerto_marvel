using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelCore.Models;

namespace MarvelCore.Service
{
    public class MockMarvelService : IMarvelService
    {
        public List<MarvelHero> GetMockedList() {

            var mocked = new List<MarvelHero>();

            mocked.Add(new MarvelHero { Id = 1, Description = "Adolecente com poderes elétricos", Name = "Super Shock", Thumbnail = new Thumbnail {Extension = ".jpeg", Path= "https://kanto.legiaodosherois.com.br/w750-h393-gnw-cfill-q80/wp-content/uploads/2018/07/legiao_1MzfrgRiXd5w3WB_x62eGvInaQHEsAYhFm4oStkVTJ.jpg" }, Histories = GenerateRandomHistoryList() });
            mocked.Add(new MarvelHero { Id = 2, Description = "Adolecente com poderes de aranha", Name = "Homem Aranha", Thumbnail = new Thumbnail { Extension = ".jpg", Path = "http://4.bp.blogspot.com/-2hjM0kapBis/VYm7zBzI1XI/AAAAAAAACRI/kyXeZ6DbrGs/s320/RomitaClassicArt" }, Histories = GenerateRandomHistoryList() });
            mocked.Add(new MarvelHero { Id = 3, Description = "Vigilante armado buscando vingança", Name = "Justiceiro", Thumbnail = new Thumbnail { Extension = ".png", Path = "https://www.expertcomics.com/images/heroes/Punisher" }, Histories = GenerateRandomHistoryList() });
            mocked.Add(new MarvelHero { Id = 4, Description = "Um homem nervoso e verde", Name = "Hulk", Thumbnail = new Thumbnail { Extension = ".png", Path = "https://upload.wikimedia.org/wikipedia/en/5/59/Hulk_%28comics_character%29" }, Histories = GenerateRandomHistoryList() });

            return mocked;
        }

        private List<string> GenerateRandomHistoryList() {
            Random rd = new Random();
            int n = rd.Next(50);
            var res = new List<string>();

            for (var x = 1; x < n; x++) {

                res.Add("Historia " + x.ToString());
            }

            return res;
        }

        public async Task<List<MarvelHero>> SearchHeroes(string input, int page)
        {
            var list = GetMockedList();

            if (!String.IsNullOrEmpty(input)) {

                list = list.Where(h => h.Name.ToLower().Contains(input.ToLower())).ToList();
            }

            return list;
        }
    }
}
