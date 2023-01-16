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
    public class ReviewRepository : ISharedRepository<Ereview>
    {
        private readonly IDbContext _dbContext;

    public ReviewRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

        public Ereview Create(Ereview ereview)
        {
            var p = new DynamicParameters();
            p.Add("Opin", ereview.Opinion, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IdUser", ereview.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EReview_Package.CreateReview", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ReviewID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EReview_Package.DeleteReview", p, commandType: CommandType.StoredProcedure);
        }

        public List<Ereview> GetAll()
        {
            IEnumerable<Ereview> result = _dbContext.Connection.Query<Ereview>("EReview_Package.GetAllReview", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ereview GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ReviewID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Ereview> result = _dbContext.Connection.Query<Ereview>("EReview_Package.GetReviewById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Ereview Update(Ereview ereview)
        {
            var p = new DynamicParameters();
            p.Add("ReviewID", ereview.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Opin", ereview.Opinion, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EReview_Package.UpdateReview", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
