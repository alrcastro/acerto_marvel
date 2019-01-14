using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCore.Models
{
    public class SearchHistory
    {
        public string Id { get; set; }
        public DateTime SearchDate { get; set; }
        public string Input { get; set; }
    }
}
