using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class Trandau
    {
        public decimal Matran { get; set; }
        public int Nam { get; set; }
        public int Vong { get; set; }
        public DateTime Ngaytd { get; set; }
        public string Maclb1 { get; set; }
        public string Maclb2 { get; set; }
        public string Masan { get; set; }
        public string Ketqua { get; set; }

        public virtual Caulacbo Maclb1Navigation { get; set; }
        public virtual Caulacbo Maclb2Navigation { get; set; }
        public virtual Sanvd MasanNavigation { get; set; }
    }
}
