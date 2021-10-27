using System;
using FootballManaga.Models;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class Huanluyenvien
    {
        public Huanluyenvien()
        {
            HlvClb = new HashSet<HlvClb>();
        }

        public string Mahlv { get; set; }
        public string Tenhlv { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }
        public string Maqg { get; set; }

        public virtual Quocgia MaqgNavigation { get; set; }
        public virtual ICollection<HlvClb> HlvClb { get; set; }
        public virtual ICollection<IndexModelsViews> IndexModelsViews { get; set; }
    }
}
