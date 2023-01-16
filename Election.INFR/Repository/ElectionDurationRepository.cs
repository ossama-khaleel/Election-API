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
    public class ElectionDurationRepository : ISharedRepository<Eelectionduration>
    {
        private readonly IDbContext _dbContext;

        public ElectionDurationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Eelectionduration> GetAll()
        {
            IEnumerable<Eelectionduration> result = _dbContext.Connection.Query<Eelectionduration>("EElectionDuration_Package.GetAllElectionDuration" , commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public Eelectionduration GetById(int id)
        {
            var p =new DynamicParameters();
            p.Add("DurationID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eelectionduration> result = _dbContext.Connection.Query<Eelectionduration>("EElectionDuration_Package.GetElectionDurationById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Eelectionduration Create(Eelectionduration eelectionduration)
        {
            var p = new DynamicParameters();
            p.Add("StartDate", eelectionduration.Electionstartdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("EndDate", eelectionduration.Electionenddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("CatID", eelectionduration.Categoryid,  dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EElectionDuration_Package.CreateElectionDuration" , p , commandType:CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public Eelectionduration Update(Eelectionduration eelectionduration)
        {
            var p = new DynamicParameters();
            p.Add("DurationID", eelectionduration.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("StartDate", eelectionduration.Electionstartdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("EndDate", eelectionduration.Electionenddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("CatID", eelectionduration.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result",  dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EElectionDuration_Package.UpdateElectionDuration", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("DurationID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EElectionDuration_Package.DeleteElectionDuration" , p , commandType:CommandType.StoredProcedure);
        }
    }
}
