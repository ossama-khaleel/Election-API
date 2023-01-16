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
    public class AboutuRepository : ISharedRepository<Eaboutu>
    {
        private readonly IDbContext _dbContext;

        public AboutuRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Eaboutu Create(Eaboutu eaboutu)
        {
            var p = new DynamicParameters();
            p.Add("NameAbout", eaboutu.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EmailAbout", eaboutu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PhoneNumberAbout", eaboutu.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IdHome", eaboutu.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EABOUTUS_Package.CreateABOUTUS", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("AboutusId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EABOUTUS_Package.DeleteABOUTUS", p, commandType: CommandType.StoredProcedure);
        }

        public List<Eaboutu> GetAll()
        {
            IEnumerable<Eaboutu> result = _dbContext.Connection.Query<Eaboutu>("EABOUTUS_Package.GetAllABOUTUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Eaboutu GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("AboutusId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eaboutu> result = _dbContext.Connection.Query<Eaboutu>("EABOUTUS_Package.GetABOUTUSById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Eaboutu Update(Eaboutu eaboutu)
        {
            var p = new DynamicParameters();
            p.Add("AboutusId", eaboutu.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NameAbout", eaboutu.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EmailAbout", eaboutu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PhoneNumberAbout", eaboutu.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EABOUTUS_Package.UpdateABOUTUS", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
