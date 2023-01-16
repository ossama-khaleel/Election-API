using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Repository
{
    public interface ISharedRepository<DB>
    {
        public List<DB> GetAll();
        public DB GetById(int id);
        public void Delete(int id);
        public DB Create(DB dB);
        public DB Update(DB dB);
    }
}
