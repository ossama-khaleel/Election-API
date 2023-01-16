using Dapper;
using Election.CORE.Common;
using Election.CORE.Data;
using Election.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Election.INFR.Repository
{
    public class JWTRepository : IJWTRepository
    {
        private readonly IDbContext _dbContext;

        public JWTRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Euser Auth(Euser euser)
        {
            var p = new DynamicParameters();
            p.Add("SSNumber", euser.Ssn, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Pas", euser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Euser>("EUser_Package.Login" , p , commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
