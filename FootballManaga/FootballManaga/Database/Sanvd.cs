using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class Sanvd
    {
        public Sanvd()
        {
            Caulacbo = new HashSet<Caulacbo>();
            Trandau = new HashSet<Trandau>();
        }

        public string Masan { get; set; }
        public string Tensan { get; set; }
        public string Diachi { get; set; }

        public virtual ICollection<Caulacbo> Caulacbo { get; set; }
        public virtual ICollection<Trandau> Trandau { get; set; }
    }
}
