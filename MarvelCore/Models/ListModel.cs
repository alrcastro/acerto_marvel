using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCore.Models
{
    public class ListModel
    {
        public string SearchText { get; set; }
        public List<MarvelHero> Items { get; set; }
        public int Page { get; set; }
    }
}
