using Election.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Repository
{
    public interface IMunicipalStatusRepository
    {
        public List<Emunicipalstatus> Search(string name);
       
    }
}
