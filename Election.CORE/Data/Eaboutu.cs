using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Eaboutu
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Phonenumber { get; set; }
        public decimal? Homeid { get; set; }

        public virtual Ehome Home { get; set; }
    }
}
