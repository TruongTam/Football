using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class Bangxh
    {
        public string Maclb { get; set; }
        public int Nam { get; set; }
        public int Vong { get; set; }
        public int Sotran { get; set; }
        public int Thang { get; set; }
        public int Hoa { get; set; }
        public int Thua { get; set; }
        public string Hieuso { get; set; }
        public int Diem { get; set; }
        public int Hang { get; set; }

        public virtual Caulacbo MaclbNavigation { get; set; }
    }
}
