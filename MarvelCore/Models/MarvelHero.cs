using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCore.Models
{
    public class MarvelHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Histories { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public string ResourceURI { get; set; }

        public string LimitedDescription { get {
                if (Description.Length > 200)
                    return Description.Substring(0, 200);
                return Description;
            } }
    }

    public class Thumbnail {
        public string Path { get; set; }
        public string Extension { get; set; }
        public string URI { get {
                return Path + Extension;
            } }
    }
}
