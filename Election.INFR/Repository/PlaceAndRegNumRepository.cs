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
    public class PlaceAndRegNumRepository : ISharedRepository<Eplaceandregnum>
    {
        private readonly IDbContext _dbContext;

        public PlaceAndRegNumRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Eplaceandregnum> GetAll()
        {
            IEnumerable<Eplaceandregnum> result = _dbContext.Connection.Query<Eplaceandregnum>("EPlaceandregnum_Package.GetAllPlaceandregnum", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Eplaceandregnum GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("EPlaceandregnumId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eplaceandregnum> result = _dbContext.Connection.Query<Eplaceandregnum>("EPlaceandregnum_Package.GetPlaceandregnumById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Eplaceandregnum Create(Eplaceandregnum eplaceandregnum)
        {
            var p = new DynamicParameters();
            p.Add("PLACEANDREGNUM", eplaceandregnum.Placeandregnum, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPlaceandregnum_Package.CREATEPlaceandregnum", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("EPlaceandregnumId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EPlaceandregnum_Package.DeletePlaceandregnum", p, commandType: CommandType.StoredProcedure);
          
        }

        public Eplaceandregnum Update(Eplaceandregnum eplaceandregnum)
        {
            var p = new DynamicParameters();
            p.Add("EPlaceandregnumId", eplaceandregnum.Id , dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PLANUM", eplaceandregnum.Placeandregnum, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPlaceandregnum_Package.UPDATEPlaceandregnum", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }

}
