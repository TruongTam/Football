using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FootballManaga.Database;

namespace FootballManaga.Models
{
    public class Club
    {
        [Key]
        public string Id { get; set; }
        [Display(Name ="Tên Câu Lạc Bộ")]
        public string Name { get; set; }
        public string Pitch { get; set; }
        public string Province { get; set; }
        public string AddProvince { get; set; }


    }
}
