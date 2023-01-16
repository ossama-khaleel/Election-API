using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Ehome
    {
        public Ehome()
        {
            Eabouts = new HashSet<Eabout>();
            Eaboutus = new HashSet<Eaboutu>();
            Econtactus = new HashSet<Econtactu>();
            Etestimonials = new HashSet<Etestimonial>();
        }

        public decimal Id { get; set; }
        public string Homeimage1 { get; set; }
        public string Homeimage2 { get; set; }
        public string Homeimage3 { get; set; }
        public string Hometitle1 { get; set; }
        public string Hometitle2 { get; set; }
        public string Hometitle3 { get; set; }

        public virtual ICollection<Eabout> Eabouts { get; set; }
        public virtual ICollection<Eaboutu> Eaboutus { get; set; }
        public virtual ICollection<Econtactu> Econtactus { get; set; }
        public virtual ICollection<Etestimonial> Etestimonials { get; set; }
    }
}
