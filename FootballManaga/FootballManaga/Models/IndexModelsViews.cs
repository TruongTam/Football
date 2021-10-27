using FootballManaga.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManaga.Models
{

    public class IndexModelsViews
    {
        [Key ]
        public string Id { get; set; }
        [Display(Name ="Tên Câu Lạc Bộ")]
        public string NameClub { get; set; }
        [Display(Name = "Huấn Luyện Viên")]
        public string NameLead { get; set; }
        [Display(Name = "Thắng")]
        public int Mwin { get; set; }
        [Display(Name = "Sô Trận Thua")]
        public int Mlost { get; set; }
        [Display(Name = "Diểm")]
        public int Point { get; set; }
        [Display(Name = "Xết Hạng")]
        public int Rank { get; set; }
        public List<Huanluyenvien> huanluyenvien { get; set; }
    }
}
