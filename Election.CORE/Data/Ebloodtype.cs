using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Ebloodtype
    {
        public Ebloodtype()
        {
            Euserinformations = new HashSet<Euserinformation>();
        }

        public decimal Id { get; set; }
        public string Bloodtype { get; set; }

        public virtual ICollection<Euserinformation> Euserinformations { get; set; }
    }
}
