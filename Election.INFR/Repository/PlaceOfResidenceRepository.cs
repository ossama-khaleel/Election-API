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
    public class PlaceOfResidenceRepository : ISharedRepository<Eplaceofresidence>
    {
        private readonly IDbContext _dbContext;
        public PlaceOfResidenceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Eplaceofresidence Create(Eplaceofresidence eplaceofresidence)
        {
            var p = new DynamicParameters();
            p.Add("PlaceOfRes", eplaceofresidence.Placeofresidence, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPlaceOfResidence_Package.CreatePlaceOfResidence", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("PlaceOfResidenceID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EPlaceOfResidence_Package.DeletePlaceOfResidence", p, commandType: CommandType.StoredProcedure);
        }

        public List<Eplaceofresidence> GetAll()
        {
            IEnumerable<Eplaceofresidence> result = _dbContext.Connection.Query<Eplaceofresidence>("EPlaceOfResidence_Package.GetAllPlaceOfResidence", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Eplaceofresidence GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("PlaceOfResidenceID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eplaceofresidence> result = _dbContext.Connection.Query<Eplaceofresidence>("EPlaceOfResidence_Package.GetPlaceOfResidenceById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Eplaceofresidence Update(Eplaceofresidence eplaceofresidence)
        {
            var p = new DynamicParameters();
            p.Add("PlaceOfResidenceID", eplaceofresidence.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PlaceOfRes", eplaceofresidence.Placeofresidence, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPlaceOfResidence_Package.UpdatePlaceOfResidence", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
