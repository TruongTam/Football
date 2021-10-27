using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class Quocgia
    {
        public Quocgia()
        {
            Cauthu = new HashSet<Cauthu>();
            Huanluyenvien = new HashSet<Huanluyenvien>();
        }

        public string Maqg { get; set; }
        public string Tenqg { get; set; }

        public virtual ICollection<Cauthu> Cauthu { get; set; }
        public virtual ICollection<Huanluyenvien> Huanluyenvien { get; set; }
    }
}
