using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.DTO
{
    public class HomeTestimonial
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public decimal? Acceptstatus { get; set; }
        public decimal? Homeid { get; set; }
        public decimal? Userid { get; set; }
        public string Userimagepath { get; set; }
    }
}
