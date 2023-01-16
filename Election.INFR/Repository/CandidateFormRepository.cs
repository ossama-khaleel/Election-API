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
    public class CandidateFormRepository : ISharedRepository<Ecandidateform>
    {
        private readonly IDbContext _dbContext;

        public CandidateFormRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Ecandidateform> GetAll()
        {
            IEnumerable<Ecandidateform> result = _dbContext.Connection.Query<Ecandidateform>("ECandidateForm_Package.GetAllCandidateForm", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public Ecandidateform GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("CandidateFormID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Ecandidateform> result = _dbContext.Connection.Query<Ecandidateform>("ECandidateForm_Package.GetCandidateFormById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Ecandidateform Create(Ecandidateform ecandidateform)
        {
            var p = new DynamicParameters();
            p.Add("Namee", ecandidateform.Candidatename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Status", ecandidateform.Acceptstatus, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Category", ecandidateform.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("User", ecandidateform.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ECandidateForm_Package.CreateCandidateForm", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);

        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("CandidateFormID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ECandidateForm_Package.DeleteCandidateForm", p, commandType: CommandType.StoredProcedure);
        }

        public Ecandidateform Update(Ecandidateform ecandidateform)
        {
            var p = new DynamicParameters();
            p.Add("CandidateFormID", ecandidateform.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Namee", ecandidateform.Candidatename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Status", ecandidateform.Acceptstatus, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Category", ecandidateform.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("User", ecandidateform.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ECandidateForm_Package.UpdateCandidateForm", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
