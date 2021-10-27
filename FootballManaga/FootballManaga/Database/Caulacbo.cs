using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class Caulacbo
    {
        public Caulacbo()
        {
            Bangxh = new HashSet<Bangxh>();
            Cauthu = new HashSet<Cauthu>();
            HlvClb = new HashSet<HlvClb>();
            TrandauMaclb1Navigation = new HashSet<Trandau>();
            TrandauMaclb2Navigation = new HashSet<Trandau>();
        }

        public string Maclb { get; set; }
        public string Tenclb { get; set; }
        public string Masan { get; set; }
        public string Matinh { get; set; }

        public virtual Sanvd MasanNavigation { get; set; }
        public virtual Tinh MatinhNavigation { get; set; }
        public virtual ICollection<Bangxh> Bangxh { get; set; }
        public virtual ICollection<Cauthu> Cauthu { get; set; }
        public virtual ICollection<HlvClb> HlvClb { get; set; }
        public virtual ICollection<Trandau> TrandauMaclb1Navigation { get; set; }
        public virtual ICollection<Trandau> TrandauMaclb2Navigation { get; set; }
    }
}
