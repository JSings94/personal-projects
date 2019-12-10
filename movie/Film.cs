using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearch
{
    public class Film
    {
        public int id { get; set; }
        public string title { get; set; }
        public string posterpath { get; set; }
        public DateTime? releasedate { get; set; }
        public string overview { get; set; }
    }
}
