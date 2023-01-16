using Election.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Service
{
    public interface IRegisterService
    {
        public Euserinformation Register(decimal ssn);
    }
}
