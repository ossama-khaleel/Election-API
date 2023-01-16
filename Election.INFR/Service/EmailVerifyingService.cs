using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class EmailVerifyingService : IEmailVerifyingService
    {
        private readonly IEmailVerifyingRepository _emailVerifyingRepository;

        public EmailVerifyingService(IEmailVerifyingRepository emailVerifyingRepository)
        {
            _emailVerifyingRepository = emailVerifyingRepository;
        }

        public void Verifying(int id)
        {
            _emailVerifyingRepository.Verifying(id);
        }
    }
}
