using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class Tinh
    {
        public Tinh()
        {
            Caulacbo = new HashSet<Caulacbo>();
        }

        public string Matinh { get; set; }
        public string Tentinh { get; set; }

        public virtual ICollection<Caulacbo> Caulacbo { get; set; }
    }
}
