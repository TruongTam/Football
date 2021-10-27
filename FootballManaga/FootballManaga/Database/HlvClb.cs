using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class HlvClb
    {
        public string Mahlv { get; set; }
        public string Maclb { get; set; }
        public string Vaitro { get; set; }

        public virtual Caulacbo MaclbNavigation { get; set; }
        public virtual Huanluyenvien MahlvNavigation { get; set; }
    }
}
