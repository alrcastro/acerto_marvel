using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarvelCore.Models;
using Microsoft.AspNetCore.Authorization;
using MarvelCore.Service;

namespace MarvelCore.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        IMarvelService _marvelService;
        IHistorySearchService _historySearchService;

        public HomeController(IMarvelService marvelService, IHistorySearchService historySearchService) {
            _marvelService = marvelService;
            _historySearchService = historySearchService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> List(ListModel search)
        {            
            List<MarvelHero> heroes;
            
            if (search?.SearchText == null)
                heroes = await _marvelService.SearchHeroes("", 1);
            else { 
                heroes = await _marvelService.SearchHeroes(search.SearchText, 1);
                _historySearchService.AddHistory(GetUser(),search.SearchText,DateTime.Now);
            }
            var model = new ListModel { Items = heroes, Page = 1 };

            return View(model);
        }

        public IActionResult Details() {
            return View();
        }
     
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
