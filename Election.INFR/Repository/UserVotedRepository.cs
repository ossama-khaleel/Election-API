using Dapper;
using Election.CORE.Common;
using Election.CORE.Data;
using Election.CORE.DTO;
using Election.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Election.INFR.Repository
{
    public class UserVotedRepository : ISharedRepository<Euservoted> , IUserVotedRepository
    {
        private readonly IDbContext _dbContext;
        public UserVotedRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Chart> Chart()
        {
            IEnumerable<Chart> result = _dbContext.Connection.Query<Chart>("EUserVoted_Package.Chart", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Euservoted Create(Euservoted euservoted)
        {
            var p = new DynamicParameters();
            p.Add("UsrrId", euservoted.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CandidatesIId", euservoted.Candidatesid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MuniStatusId", euservoted.Municipalstatusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("DateVote", euservoted.Votedate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EUserVoted_Package.CreateUserVoted", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserVotedId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EUserVoted_Package.DeleteUserVoted", p, commandType: CommandType.StoredProcedure);
        }

        public List<Euservoted> GetAll()
        {
            IEnumerable<Euservoted> result = _dbContext.Connection.Query<Euservoted>("EUserVoted_Package.GetAllUserVoted", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Euservoted GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserVotedId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Euservoted> result = _dbContext.Connection.Query<Euservoted>("EUserVoted_Package.GetUserVotedById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<TotalVotes> TotalVotes()
        {
            IEnumerable<TotalVotes> result = _dbContext.Connection.Query<TotalVotes>("EUserVoted_Package.TotalVotesForEachCandidate", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Euservoted Update(Euservoted euservoted)
        {
            var p = new DynamicParameters();
            p.Add("UserVotedId", euservoted.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UsrrId", euservoted.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CandidatesIId", euservoted.Candidatesid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MuniStatusId", euservoted.Municipalstatusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("DateVote", euservoted.Votedate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EUserVoted_Package.UpdateUserVoted", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
