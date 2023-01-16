using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Repository
{
    public interface IEmailVerifyingRepository
    {
        public void Verifying(int id);
    }
}
