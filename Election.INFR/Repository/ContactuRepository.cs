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
    public class ContactuRepository : ISharedRepository<Econtactu>
    {
        private readonly IDbContext _dbContext;

        public ContactuRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Econtactu Create(Econtactu econtactu)
        {
            var p = new DynamicParameters();
            p.Add("NameCon", econtactu.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EmailCon", econtactu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("SubjectCon", econtactu.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MessageCon", econtactu.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IdHome", econtactu.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ECONTACTUS_Package.CreateCONTACTUS", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ContactID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ECONTACTUS_Package.DeleteCONTACTUS", p, commandType: CommandType.StoredProcedure);
        }

        public List<Econtactu> GetAll()
        {
            IEnumerable<Econtactu> result = _dbContext.Connection.Query<Econtactu>("ECONTACTUS_Package.GetAllCONTACTUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Econtactu GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ContactID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Econtactu> result = _dbContext.Connection.Query<Econtactu>("ECONTACTUS_Package.GetCONTACTUSById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Econtactu Update(Econtactu econtactu)
        {
            var p = new DynamicParameters();
            p.Add("ContactID", econtactu.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NameCon", econtactu.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EmailCon", econtactu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("SubjectCon", econtactu.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MessageCon", econtactu.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ECONTACTUS_Package.UpdateCONTACTUS", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
