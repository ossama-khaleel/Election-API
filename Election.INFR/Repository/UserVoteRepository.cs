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
    public class UserVoteRepository : ISharedRepository<Euservote>
    {
        private readonly IDbContext _dbContext;

        public UserVoteRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Euservote> GetAll()
        {
            
            IEnumerable<Euservote> result = _dbContext.Connection.Query<Euservote>("EUserVote_Package.GetAllUserVote", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Euservote GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserVoteId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Euservote> result = _dbContext.Connection.Query<Euservote>("EUserVote_Package.GetUserVoteById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Euservote Create(Euservote euservote)
        {
            var p = new DynamicParameters();
            p.Add("UsrId", euservote.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserMunicipal", euservote.Usermunicipalid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PresidentUserVote", euservote.President, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MemebersUserVote", euservote.Memebers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Decentra", euservote.Decentralized, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EUserVote_Package.CreateUserVote", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserVoteId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);           
            _dbContext.Connection.Execute("EUserVote_Package.DeleteUserVote", p, commandType: CommandType.StoredProcedure);
        }

        public Euservote Update(Euservote euservote)
        {
            var p = new DynamicParameters();
            p.Add("UserVoteId", euservote.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UsrId", euservote.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PresidentUserVote", euservote.President, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserMunicipal", euservote.Usermunicipalid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MemebersUserVote", euservote.Memebers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Decentra", euservote.Decentralized, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EUserVote_Package.UpdateUserVote", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
