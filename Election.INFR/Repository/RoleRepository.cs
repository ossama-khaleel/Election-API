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
    public class RoleRepository : ISharedRepository<Erole>
    {
        private readonly IDbContext _dbContext;

        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Erole> GetAll()
        {
            IEnumerable<Erole> result = _dbContext.Connection.Query<Erole>("ERole_Package.GetAllRole", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Erole GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("RoleId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Erole> result = _dbContext.Connection.Query<Erole>("ERole_Package.GetRoleById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Erole Create(Erole erole)
        {
            var p = new DynamicParameters();
            p.Add("RoleN", erole.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ERole_Package.CreateRole", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("RoleId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ERole_Package.DeleteRole", p, commandType: CommandType.StoredProcedure);
        }

        public Erole Update(Erole erole)
        {
            var p = new DynamicParameters();
            p.Add("RoleId", erole.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RoleN", erole.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ERole_Package.UpdateRole", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}


