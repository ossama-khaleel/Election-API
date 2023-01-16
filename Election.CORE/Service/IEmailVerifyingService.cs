using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Service
{
    public interface IEmailVerifyingService
    {
        public void Verifying(int id);
    }
}
