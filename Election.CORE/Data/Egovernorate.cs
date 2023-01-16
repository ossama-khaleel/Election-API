using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Egovernorate
    {
        public Egovernorate()
        {
            Emunicipalstatuses = new HashSet<Emunicipalstatus>();
            Euserinformations = new HashSet<Euserinformation>();
        }

        public decimal Id { get; set; }
        public string Governoratename { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Emunicipalstatus> Emunicipalstatuses { get; set; }
        public virtual ICollection<Euserinformation> Euserinformations { get; set; }
    }
}
