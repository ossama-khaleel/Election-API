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
    public class PlaceOfReleaseRepository : ISharedRepository<Eplaceofrelease>
    {
        private readonly IDbContext _dbContext;

        public PlaceOfReleaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Eplaceofrelease> GetAll()
        {
            IEnumerable<Eplaceofrelease> result = _dbContext.Connection.Query<Eplaceofrelease>("EPLACEOFRELEASE_Package.GetAllPlaceofrelease", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Eplaceofrelease GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("EPlaceofreleaseId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eplaceofrelease> result = _dbContext.Connection.Query<Eplaceofrelease>("EPLACEOFRELEASE_Package.GetPlaceofreleaseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Eplaceofrelease Create(Eplaceofrelease eplaceofrelease)
        {
            var p = new DynamicParameters();
            p.Add("EPlaceofreleaseName", eplaceofrelease.Placeofrelease, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPLACEOFRELEASE_Package.CREATEPlaceofrelease", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("EPlaceofreleaseId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EPLACEOFRELEASE_Package.DeletePlaceofrelease", p, commandType: CommandType.StoredProcedure);
        }

        public Eplaceofrelease Update(Eplaceofrelease eplaceofrelease)
        {
            var p = new DynamicParameters();
            p.Add("EPlaceofreleaseId",eplaceofrelease.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("EPlaceName", eplaceofrelease.Placeofrelease, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPLACEOFRELEASE_Package.UPDATEPlaceofrelease", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
