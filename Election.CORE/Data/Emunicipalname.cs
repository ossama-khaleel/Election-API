using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Emunicipalname
    {
        public Emunicipalname()
        {
            Emunicipalstatuses = new HashSet<Emunicipalstatus>();
        }

        public decimal Id { get; set; }
        public string Municipalname { get; set; }

        public virtual ICollection<Emunicipalstatus> Emunicipalstatuses { get; set; }
    }
}
