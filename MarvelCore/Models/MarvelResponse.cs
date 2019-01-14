using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCore.Models
{
    public class MarvelResponse
    {
        public CharacterDataContainer Data { get; set; }
    }

    public class CharacterDataContainer {
        public List<MarvelHero> Results { get; set; }
    }
}
