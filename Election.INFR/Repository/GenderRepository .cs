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
    public class GenderRepository : ISharedRepository<Egender>
    {
        private readonly IDbContext _dbContext;

        public GenderRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Egender> GetAll()
        {
            IEnumerable<Egender> result = _dbContext.Connection.Query<Egender>("EGender_Package.GetAllGender", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Egender GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("GenderID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Egender> result = _dbContext.Connection.Query<Egender>("EGender_Package.GetGenderById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Egender Create(Egender egender)
        {
            var p = new DynamicParameters();
            p.Add("GEN", egender.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EGender_Package.CreateGender", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("GenderID",id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EGender_Package.DeleteGender" , p , commandType:CommandType.StoredProcedure);
        }

        public Egender Update(Egender egender)
        {
            var p = new DynamicParameters();
            p.Add("GEN", egender.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("GenderID", egender.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EGender_Package.UpdateGender", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}

