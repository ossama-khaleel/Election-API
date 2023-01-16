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
    public class PlacesWithInTheMunicipalRepository : ISharedRepository<Eplaceswithinthemunicipal>
    {
        private readonly IDbContext _dbContext;

        public PlacesWithInTheMunicipalRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Eplaceswithinthemunicipal Create(Eplaceswithinthemunicipal eplaceswithinthemunicipal)
        {
            var p = new DynamicParameters();
            p.Add("PORId", eplaceswithinthemunicipal.Placeofresidenceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("villageId", eplaceswithinthemunicipal.Placeofresidencevillageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MuniStatus", eplaceswithinthemunicipal.Municipalstatusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPlacesWithinTheMunicipal_Package.CreatePlaces", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("PlacesId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EPlacesWithinTheMunicipal_Package.DeletePlaces", p, commandType: CommandType.StoredProcedure);
        }

        public List<Eplaceswithinthemunicipal> GetAll()
        {
            IEnumerable<Eplaceswithinthemunicipal> result = _dbContext.Connection.Query<Eplaceswithinthemunicipal>("EPlacesWithinTheMunicipal_Package.GetAllPlaces", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Eplaceswithinthemunicipal GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("PlacesId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eplaceswithinthemunicipal> result = _dbContext.Connection.Query<Eplaceswithinthemunicipal>("EPlacesWithinTheMunicipal_Package.GetPlacesById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Eplaceswithinthemunicipal Update(Eplaceswithinthemunicipal eplaceswithinthemunicipal)
        {
            var p = new DynamicParameters();
            p.Add("PlacesId", eplaceswithinthemunicipal.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PORId", eplaceswithinthemunicipal.Placeofresidenceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("villageId", eplaceswithinthemunicipal.Placeofresidencevillageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MuniStatus", eplaceswithinthemunicipal.Municipalstatusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPlacesWithinTheMunicipal_Package.UpdatePlaces", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
