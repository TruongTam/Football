using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballManaga.Database;

namespace FootballManaga.Models
{
    public class ListMatch
    {
        public List<IndexModelsViews> IndexModelsViews { get; set; }
        public List<Caulacbo> caulacbos { get; set; }
    }
}
