using MarvelCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCore.Service
{
    public interface IMarvelService
    {
       Task<List<MarvelHero>> SearchHeroes(string name, int page);
    }
}
