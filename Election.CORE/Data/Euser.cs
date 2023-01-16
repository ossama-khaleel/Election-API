using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Euser
    {
        public Euser()
        {
            Ecandidateforms = new HashSet<Ecandidateform>();
            Ecandidates = new HashSet<Ecandidate>();
            Ereviews = new HashSet<Ereview>();
            Etestimonials = new HashSet<Etestimonial>();
            Euservoteds = new HashSet<Euservoted>();
            Euservotes = new HashSet<Euservote>();
        }

        public decimal Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal? Ssn { get; set; }
        public string Password { get; set; }
        public string Userimagepath { get; set; }
        public string Email { get; set; }
        public string Idfrontimage { get; set; }
        public string Idbackimage { get; set; }
        public decimal? Userinfoid { get; set; }
        public int? Phonenumber { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Verified { get; set; }

        public virtual Erole Role { get; set; }
        public virtual Euserinformation Userinfo { get; set; }
        public virtual ICollection<Ecandidateform> Ecandidateforms { get; set; }
        public virtual ICollection<Ecandidate> Ecandidates { get; set; }
        public virtual ICollection<Ereview> Ereviews { get; set; }
        public virtual ICollection<Etestimonial> Etestimonials { get; set; }
        public virtual ICollection<Euservoted> Euservoteds { get; set; }
        public virtual ICollection<Euservote> Euservotes { get; set; }
    }
}
