using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Euservote
    {
        public decimal Id { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Usermunicipalid { get; set; }
        public decimal? President { get; set; }
        public decimal? Memebers { get; set; }
        public decimal? Decentralized { get; set; }

        public virtual Euser User { get; set; }
        public virtual Eplaceswithinthemunicipal Usermunicipal { get; set; }
    }
}
