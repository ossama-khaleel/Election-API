using Dapper;
using Election.CORE.Common;
using Election.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Election.INFR.Repository
{
    public class EmailVerifyingRepository : IEmailVerifyingRepository
    {
        private readonly IDbContext _dbContext;

        public EmailVerifyingRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Verifying(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EUser_Package.Verifying", p, commandType: CommandType.StoredProcedure);
        }
    }
}
