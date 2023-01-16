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
    public class CandidateRepository : ISharedRepository<Ecandidate> , ICandidateRepository
    {
        private readonly IDbContext _dbContext;

        public CandidateRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Ecandidate> GetAll()
        {
            IEnumerable<Ecandidate> result = _dbContext.Connection.Query<Ecandidate>("ECandidates_Package.GetAllCandidates" , commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ecandidate GetById(int id)
        {
            var p =new DynamicParameters();
            p.Add("ECandidatesid", id , dbType:DbType.Int32 , direction:ParameterDirection.Input);
            IEnumerable<Ecandidate> result = _dbContext.Connection.Query<Ecandidate>("ECandidates_Package.GetCandidatesById", p , commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Ecandidate Create(Ecandidate ecandidate)
        {
            var p = new DynamicParameters();
            p.Add("ECanCatId", ecandidate.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ECanMuStatusid", ecandidate.Municipalstatusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserId", ecandidate.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CanFormId", ecandidate.Candidateformid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ECandidatesName", ecandidate.Candidatename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DES", ecandidate.Des, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result_Status", ecandidate.Resultstatus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CANDIDATEIMAGEPATH", ecandidate.Candidateimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ECandidates_Package.CREATECandidates", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p =new DynamicParameters();
            p.Add("ECandidatesId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ECandidates_Package.DeleteCandidates", p, commandType: CommandType.StoredProcedure);
        }

        public Ecandidate Update(Ecandidate ecandidate)
        {
            var p = new DynamicParameters();
            p.Add("ECandidatesId", ecandidate.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CatId", ecandidate.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MuStatusId", ecandidate.Municipalstatusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserId", ecandidate.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CanFormId", ecandidate.Candidateformid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ECanName", ecandidate.Candidatename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CanDES", ecandidate.Des, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result_Status", ecandidate.Resultstatus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEPATH", ecandidate.Candidateimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ECandidates_Package.UPDATECandidates" , p , commandType:CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);

        }

        public List<Ecandidate> GetUserVotes(int userId)
        {
            var p = new DynamicParameters();
            p.Add("euserid", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Ecandidate> result = _dbContext.Connection.Query<Ecandidate>("ECandidates_Package.GetUserVotes", p,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateStatus(int candidateId, int status)
        {
            var p = new DynamicParameters();
            p.Add("ECandidatesId", candidateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Re", status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ECandidates_Package.UpdateResult", p, commandType: CommandType.StoredProcedure);
        }
    }
}
