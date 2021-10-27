using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class Username
    {
        public int? Id { get; set; }
        public string Username1 { get; set; }
        public string Pass { get; set; }
        public int? Role { get; set; }
    }
}
