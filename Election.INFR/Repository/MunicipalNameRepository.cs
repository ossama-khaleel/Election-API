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
    public class MunicipalNameRepository : ISharedRepository<Emunicipalname>, IMunicipalNameRepository
    {
        private readonly IDbContext _dbContext;

        public MunicipalNameRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Emunicipalname> GetAll()
        {
            IEnumerable<Emunicipalname> result = _dbContext.Connection.Query<Emunicipalname>("EMunicipalName_Package.GetAllMunicipalName", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Emunicipalname GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("MunicipalNameID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Emunicipalname> result = _dbContext.Connection.Query<Emunicipalname>("EMunicipalName_Package.GetMunicipalNameById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Emunicipalname Create(Emunicipalname emunicipalname)
        {
            var p = new DynamicParameters();
            p.Add("MuniName", emunicipalname.Municipalname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EMunicipalName_Package.CreateMunicipalName", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("MunicipalNameID", id , dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EMunicipalName_Package.DeleteMunicipalName", p, commandType: CommandType.StoredProcedure);
        }

        public Emunicipalname Update(Emunicipalname emunicipalname)
        {
            var p = new DynamicParameters();
            p.Add("MunicipalNameID", emunicipalname.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MuniName", emunicipalname.Municipalname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EMunicipalName_Package.UpdateMunicipalName", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public List<Emunicipalname> Search(string name)
        {
            var p = new DynamicParameters();
            p.Add("Name", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Emunicipalname> result = _dbContext.Connection.Query<Emunicipalname>("EMunicipalName_Package.SearchMunicipalName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
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
