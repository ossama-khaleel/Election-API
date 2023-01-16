using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Euserinformation
    {
        public decimal Id { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Lastname { get; set; }
        public string Mothername { get; set; }
        public string Fullname { get; set; }
        public decimal? Genderid { get; set; }
        public decimal? Placeofbirthid { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public decimal? Placeandregnumid { get; set; }
        public DateTime? Expiry { get; set; }
        public decimal? Placeofreleaseid { get; set; }
        public decimal? Placeofresidenceid { get; set; }
        public decimal? Placeofresidencevillageid { get; set; }
        public string Userimagepath { get; set; }
        public decimal? Ssn { get; set; }
        public decimal? Bloodtypeid { get; set; }

        public virtual Ebloodtype Bloodtype { get; set; }
        public virtual Egender Gender { get; set; }
        public virtual Eplaceandregnum Placeandregnum { get; set; }
        public virtual Egovernorate Placeofbirth { get; set; }
        public virtual Eplaceofrelease Placeofrelease { get; set; }
        public virtual Eplaceofresidence Placeofresidence { get; set; }
        public virtual Eplaceofresidencevillage Placeofresidencevillage { get; set; }
        public virtual Euser Euser { get; set; }
    }
}
