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
        public IActionResult Index(string type) {
            type = "UName";
            string type1 = "URank";
            ViewBag.type = type;
            ViewBag.type1 = type1;
            var rs = GetList().OrderByDescending(x=>x.Rank);
            var clb = context.Caulacbo.ToList().OrderByDescending(x => x.Tenclb);
            switch (type)
            {
                case "UName": return View("Index", Sort("UName"));
                    break;
                case "DName": return View("Index", Sort("DName"));
                    break;
                case "URank": return View("Index", Sort("URank"));
                    break;
                case "DRank": return View("Index", Sort("DRank"));
                    break;
                case ""     :
                    return View("Index", new ListMatch
                    {
                        IndexModelsViews = rs.ToList(),
                        caulacbos = clb.ToList()
                    });
                   
            }
            return View("Index", Search(type));
        }
        public IActionResult AddClub()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddClub(Club club)
        {
            //Club clubN = new Club(club.Id, club.Name, club.Pitch, club.Province, club.AddProvince);
            club.addClub(club.Id, club.Name, club.Pitch, club.Province, club.AddProvince);

            return View();
        }
        public ListMatch Sort(string type)
        {
            var x= new List<IndexModelsViews>();

            if (type == "UName") { x=GetList().OrderBy(x => x.NameClub).ToList(); }
            if (type == "URank") { x=GetList().OrderBy(x => x.Rank).ToList(); }
            if (type == "DName") { x=GetList().OrderByDescending(x => x.NameClub).ToList(); }
            if (type == "DRank") { x=GetList().OrderByDescending(x => x.Rank).ToList(); }
            var clb = context.Caulacbo.ToList();
            ListMatch listMatch = new ListMatch
            {
                IndexModelsViews = x,
                caulacbos = clb
            };
            return listMatch;
        }
        
        public IActionResult Club()
        {
            var x = context.Caulacbo.Join(context.Tinh,
                c => c.Matinh,
                t => t.Matinh,
                (c, t) => new
                {
                    Id = c.Maclb,
                    Name = c.Tenclb,
                    Province = t.Tentinh,
                    IdP = c.Masan
                }
                ).Join(context.Sanvd,
                i => i.IdP,
                s => s.Masan,
                (i, s) => new Club
                (
                    i.Id,
                    i.Name,
                    i.Province,
                    s.Tensan,
                    s.Diachi
                )
                ).ToList();
            return View(demo(x));
        }
        public List<Club> demo(List<Club> a)
        {
            return a.OrderByDescending(x => x.Name).ToList();
        }


     
        public ListMatch Search(string name)
        {
            ViewBag.check = "";
           
            if (string.IsNullOrEmpty(name))
            {
                 ViewBag.check= name;
            }
            var indexModels = GetList().Where(c => c.NameClub.Contains(name) || c.NameLead.Contains(name));
            var clb = context.Caulacbo.ToList();


            return new ListMatch
            {
                IndexModelsViews = indexModels.ToList(),
                caulacbos = clb
            };
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
