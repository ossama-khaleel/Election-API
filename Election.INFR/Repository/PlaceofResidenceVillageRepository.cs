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
    public class PlaceofResidenceVillageRepository : ISharedRepository<Eplaceofresidencevillage>
    {
        private readonly IDbContext _dbContext;

        public PlaceofResidenceVillageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Eplaceofresidencevillage> GetAll()
        {
            IEnumerable<Eplaceofresidencevillage> result = _dbContext.Connection.Query<Eplaceofresidencevillage>("EPlaceOfResidenceVillage_Package.GetAllVillage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Eplaceofresidencevillage GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("VillageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Eplaceofresidencevillage> result = _dbContext.Connection.Query<Eplaceofresidencevillage>("EPlaceOfResidenceVillage_Package.GetVillageById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Eplaceofresidencevillage Create(Eplaceofresidencevillage eplaceofresidencevillage)
        {
            var p = new DynamicParameters();
            p.Add("VillageN", eplaceofresidencevillage.Placeofresidencevillage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPlaceOfResidenceVillage_Package.CreateVillage", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("VillageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EPlaceOfResidenceVillage_Package.DeleteVillage", p, commandType: CommandType.StoredProcedure);
        }

        public Eplaceofresidencevillage Update(Eplaceofresidencevillage eplaceofresidencevillage)
        {
            var p = new DynamicParameters();
            p.Add("VillageId", eplaceofresidencevillage.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("VillageN", eplaceofresidencevillage.Placeofresidencevillage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EPlaceOfResidenceVillage_Package.UpdateVillage", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
