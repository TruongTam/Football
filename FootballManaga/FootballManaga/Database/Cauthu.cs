using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class Cauthu
    {
        public decimal Mact { get; set; }
        public string Hoten { get; set; }
        public string Vitri { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Diachi { get; set; }
        public string Maclb { get; set; }
        public string Maqg { get; set; }
        public int So { get; set; }

        public virtual Caulacbo MaclbNavigation { get; set; }
        public virtual Quocgia MaqgNavigation { get; set; }
    }
}
