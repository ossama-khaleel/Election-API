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
    public class MunicipalStatusRepository : ISharedRepository<Emunicipalstatus>, IMunicipalStatusRepository
    {
        private readonly IDbContext _dbContext;

        public MunicipalStatusRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Emunicipalstatus Create(Emunicipalstatus emunicipalstatus)
        {
            var p = new DynamicParameters();
            p.Add("MunicipalNameId", emunicipalstatus.Municipalnameid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MunicipalPresident", emunicipalstatus.President, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MunicipalMemebers", emunicipalstatus.Memebers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MunicipalDecentralized", emunicipalstatus.Decentralized, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MuniPlaceId", emunicipalstatus.Governorateid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EMunicipalStatus_Package.CreateMunicipalStatus", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("MunicipalStatusID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EMunicipalStatus_Package.DeleteMunicipalStatus", p, commandType: CommandType.StoredProcedure);
        }

        public List<Emunicipalstatus> GetAll()
        {
            var result = _dbContext.Connection.Query<Emunicipalstatus>("EMunicipalStatus_Package.GetAllMunicipalStatus", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Emunicipalstatus GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("MunicipalStatusID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Emunicipalstatus> result = _dbContext.Connection.Query<Emunicipalstatus>("EMunicipalStatus_Package.GetMunicipalStatusById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    

        public List<Emunicipalstatus> Search(string name)
        {
            var p = new DynamicParameters();
            p.Add("Name", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Emunicipalstatus> result = _dbContext.Connection.Query<Emunicipalstatus>("EMunicipalStatus_Package.SearchMunicipalStatus", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Emunicipalstatus Update(Emunicipalstatus emunicipalstatus)
        {
            var p = new DynamicParameters();
            p.Add("MunicipalStatusID", emunicipalstatus.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MunicipalNameId", emunicipalstatus.Municipalnameid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MunicipalPresident", emunicipalstatus.President, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MunicipalMemebers", emunicipalstatus.Memebers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MunicipalDecentralized", emunicipalstatus.Decentralized, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MuniPlaceId", emunicipalstatus.Governorateid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EMunicipalStatus_Package.UpdateMunicipalStatus", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
