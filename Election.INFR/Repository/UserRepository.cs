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
    public class UserRepository : ISharedRepository<Euser>, IRegisterRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Euserinformation Register(decimal ssn)
        {
            var p = new DynamicParameters();
            p.Add("SSNumber", ssn, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            IEnumerable<Euserinformation> result = _dbContext.Connection.Query<Euserinformation>("EUser_Package.Register", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Euser Create(Euser euser)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("FName", euser.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("LName", euser.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("SSNumber", euser.Ssn, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("Pass", euser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("UserImageName", euser.Userimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("UserEmail", euser.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("FrontImageId", euser.Idfrontimage, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("BackImageId", euser.Idbackimage, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("IdUserInfo", euser.Userinfoid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("PhoneNum", euser.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("RoleId", euser.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                _dbContext.Connection.Execute("EUser_Package.CreateUser", p, commandType: CommandType.StoredProcedure);
                int id = p.Get<int>("result");
                return GetById(id);
            }
            catch 
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EUser_Package.DeleteUser", p, commandType: CommandType.StoredProcedure);
        }

        public List<Euser> GetAll()
        {
            IEnumerable<Euser> result = _dbContext.Connection.Query<Euser>("EUser_Package.GetAllUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Euser GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Euser> result = _dbContext.Connection.Query<Euser>("EUser_Package.GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Euser Update(Euser euser)
        {
            var p = new DynamicParameters();
            p.Add("UserID", euser.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Pass", euser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UserEmail", euser.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PhoneNum", euser.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RoleId", euser.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FName", euser.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LName", euser.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ImageName", euser.Userimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EUser_Package.UpdateUser", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
