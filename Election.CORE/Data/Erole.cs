using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Erole
    {
        public Erole()
        {
            Eusers = new HashSet<Euser>();
        }

        public decimal Id { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<Euser> Eusers { get; set; }
    }
}
