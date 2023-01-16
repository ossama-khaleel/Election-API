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
    public class GovernorateRepository : ISharedRepository<Egovernorate>
    {
        private readonly IDbContext _dbContext;

        public GovernorateRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Egovernorate> GetAll()
        {
            IEnumerable<Egovernorate> result = _dbContext.Connection.Query<Egovernorate>("EGovernorate_Package.GetAllEGovernorate", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Egovernorate GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("PlaceId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Egovernorate> result = _dbContext.Connection.Query<Egovernorate>("EGovernorate_Package.GetEGovernorateById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Egovernorate Create(Egovernorate egovernorate)
        {
            var p = new DynamicParameters();
            p.Add("Place", egovernorate.Governoratename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EGovernorate_Package.CreateEGovernorate", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("PlaceId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EGovernorate_Package.DeleteEGovernorate", p, commandType: CommandType.StoredProcedure);
        }

        public Egovernorate Update(Egovernorate egovernorate)
        {
            var p = new DynamicParameters();
            p.Add("PlaceId", egovernorate.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Place", egovernorate.Governoratename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EGovernorate_Package.UpdateEGovernorate", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
//public List<Ebloodtype> GetAll()
//{
//    IEnumerable<Ebloodtype> result = _dbContext.Connection.Query<Ebloodtype>("EBloodtype_Package.GetAllBloodtype", commandType: CommandType.StoredProcedure);
//    return result.ToList();
//}

//public Ebloodtype GetById(int id)
//{
//    var p = new DynamicParameters();
//    p.Add("BloodID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
//    IEnumerable<Ebloodtype> result = _dbContext.Connection.Query<Ebloodtype>("EBloodtype_Package.GetBloodtypeById", p, commandType: CommandType.StoredProcedure);
//    return result.FirstOrDefault();
//}

//public Ebloodtype Create(Ebloodtype ebloodtype)
//{
//    var p = new DynamicParameters();
//    p.Add("BType", ebloodtype.Bloodtype, dbType: DbType.String, direction: ParameterDirection.Input);
//    p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
//    _dbContext.Connection.Execute("EBloodtype_Package.CreateBloodtype", p, commandType: CommandType.StoredProcedure);
//    int id = p.Get<int>("result");
//    return GetById(id);
//}

//public void Delete(int id)
//{
//    var p = new DynamicParameters();
//    p.Add("BloodID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
//    _dbContext.Connection.Execute("EBloodtype_Package.DeleteBloodtype", p, commandType: CommandType.StoredProcedure);
//}

//public Ebloodtype Update(Ebloodtype ebloodtype)
//{
//    var p = new DynamicParameters();
//    p.Add("BType", ebloodtype.Bloodtype, dbType: DbType.String, direction: ParameterDirection.Input);
//    p.Add("BloodID", ebloodtype.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
//    p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
//    _dbContext.Connection.Execute("EBloodtype_Package.UpdateBloodtype", p, commandType: CommandType.StoredProcedure);
//    int id = p.Get<int>("result");
//    return GetById(id);
//}