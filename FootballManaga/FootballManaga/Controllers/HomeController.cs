using FootballManaga.Database;
using FootballManaga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManaga.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLBongDaContext context;
        public HomeController(QLBongDaContext daContext) => context= daContext;
        public IActionResult Index() {
            var rs = GetList().OrderByDescending(x=>x.Rank);
            var clb = context.Caulacbo.ToList().OrderByDescending(x => x.Tenclb);
            ListMatch listMatch = new ListMatch
            {
                IndexModelsViews = rs.ToList(),
                caulacbos = clb.ToList()
            };

            return View(listMatch);
        }
       [HttpGet]
        public IActionResult Sort(string type)
        {
            var x= new List<IndexModelsViews>();

            if (type == "UName") { x=GetList().OrderBy(x => x.NameClub).ToList(); }
            if (type == "URank") { x=GetList().OrderBy(x => x.Rank).ToList(); }
            if (type == "DName") { x=GetList().OrderByDescending(x => x.NameClub).ToList(); }
            if (type == "DRank") { x=GetList().OrderByDescending(x => x.Rank).ToList(); }
            type = "UName";
            string type1 = "URank";
            ViewBag.type = type;
            ViewBag.type1 = type1;
            var clb = context.Caulacbo.ToList();
            ListMatch listMatch = new ListMatch
            {
                IndexModelsViews = x,
                caulacbos = clb
            };
            return View(listMatch);
        }
       public IQueryable<IndexModelsViews> GetList()
        {
            var indexliss = context.Bangxh.Join(context.Caulacbo,
               bxh => bxh.Maclb,
               clb => clb.Maclb,
               (bxh, clb) => new
               {
                   Id = bxh.Maclb,
                   Round = bxh.Vong,
                   NameClub = clb.Tenclb,
                   Mwin = bxh.Thang,
                   Mlost = bxh.Thua,
                   Point = bxh.Diem,
                   Rank = bxh.Hang
               }
               ).Join(context.HlvClb,//Where(x=>x.Round==4)
               index => index.Id,
               hlv => hlv.Maclb,
               (index, hlv) => new IndexModelsViews
               {
                   Id = index.Id,
                   NameClub = index.NameClub,
                   NameLead = hlv.Mahlv,
                   Mwin = index.Mwin,
                   Mlost = index.Mlost,
                   Point = index.Point,
                   Rank = index.Rank
               }

               ).Join(context.Huanluyenvien,
               index => index.NameLead,
               name => name.Mahlv,
               (index, name) => new IndexModelsViews
               {
                   Id = index.Id,
                   NameClub = index.NameClub,
                   NameLead = name.Tenhlv,
                   Mwin = index.Mwin,
                   Mlost = index.Mlost,
                   Point = index.Point,
                   Rank = index.Rank
               }).AsQueryable();

            return indexliss;
           
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
