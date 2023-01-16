using Election.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Repository
{
    public interface IMunicipalNameRepository
    {
        public List<Emunicipalname> Search(string name);
    }
}
