using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Etestimonial
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public decimal? Acceptstatus { get; set; }
        public decimal? Homeid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Ehome Home { get; set; }
        public virtual Euser User { get; set; }
    }
}
