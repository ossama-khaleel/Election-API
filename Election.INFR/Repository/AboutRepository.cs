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
    public class AboutRepository : ISharedRepository<Eabout>, IAboutRepository
    {
        private readonly IDbContext _dbContext;

        public AboutRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Eabout Create(Eabout eabout)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("AboutId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EABOUT_Package.DeleteABOUT", p, commandType: CommandType.StoredProcedure);
        }

        public List<Eabout> GetAll()
        {
            IEnumerable<Eabout> result = _dbContext.Connection.Query<Eabout>("EABOUT_Package.GetAllABOUT", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Eabout GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Eabout GetById1()
        {
            var p = new DynamicParameters();
            p.Add("AboutId",1, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eabout> result = _dbContext.Connection.Query<Eabout>("EABOUT_Package.GetABOUTById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public Eabout GetById2()
        {
            var p = new DynamicParameters();
            p.Add("AboutId",2, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eabout> result = _dbContext.Connection.Query<Eabout>("EABOUT_Package.GetABOUTById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public Eabout GetById3()
        {
            var p = new DynamicParameters();
            p.Add("AboutId",3, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eabout> result = _dbContext.Connection.Query<Eabout>("EABOUT_Package.GetABOUTById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public Eabout GetById4()
        {
            var p = new DynamicParameters();
            p.Add("AboutId",4, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eabout> result = _dbContext.Connection.Query<Eabout>("EABOUT_Package.GetABOUTById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Eabout Update(Eabout eabout)
        {
            var p = new DynamicParameters();
            p.Add("AboutId", eabout.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("aboutimg1", eabout.Aboutimage1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("aboutti1", eabout.Abouttitle1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EABOUT_Package.CreateABOUT", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
