using Election.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Service
{
    public interface IMunicipalStatusService
    {
        public List<Emunicipalstatus> Search(string name);
        public List<Emunicipalstatus> GetMuniByCatId(int id);
    }
}
