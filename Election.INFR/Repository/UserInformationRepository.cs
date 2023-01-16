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
    public class UserInformationRepository : ISharedRepository<Euserinformation>
    {
        private readonly IDbContext _dbContext;

        public UserInformationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Euserinformation> GetAll()
        {
            IEnumerable<Euserinformation> result = _dbContext.Connection.Query<Euserinformation>("EUserInformation_Package.GetAllUserInformation", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Euserinformation GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserInfoId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Euserinformation> result = _dbContext.Connection.Query<Euserinformation>("EUserInformation_Package.GetUserInformationById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Euserinformation Create(Euserinformation euserinformation)
        {
            var p = new DynamicParameters();
           
            p.Add("FName", euserinformation.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("SName", euserinformation.Secondname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LName", euserinformation.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MName", euserinformation.Mothername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("FUName", euserinformation.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UserInfoGender", euserinformation.Genderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoDateOfBirth", euserinformation.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceOfBirth", euserinformation.Placeofbirthid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceAndRegNum", euserinformation.Placeandregnumid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoExpiry", euserinformation.Expiry, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceOfRelease", euserinformation.Placeofreleaseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceOfResidence", euserinformation.Placeofresidenceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceOfResidenceVillage", euserinformation.Placeofresidencevillageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoUIP", euserinformation.Userimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UserInfoSSN", euserinformation.Ssn, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UserInfoBloodType", euserinformation.Bloodtypeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EUserInformation_Package.CreateUserInformation", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserInfoId", id, dbType: DbType.Int32, direction: ParameterDirection.Input); 
            _dbContext.Connection.Execute("EUserInformation_Package.DeleteUserInformation", p, commandType: CommandType.StoredProcedure);
        }

        public Euserinformation Update(Euserinformation euserinformation)
        {
            var p = new DynamicParameters();
            p.Add("UserInfoId", euserinformation.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FName", euserinformation.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("SName", euserinformation.Secondname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LName", euserinformation.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MName", euserinformation.Mothername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("FUName", euserinformation.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UserInfoGender", euserinformation.Genderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoDateOfBirth", euserinformation.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceOfBirth", euserinformation.Placeofbirthid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceAndRegNum", euserinformation.Placeandregnumid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoExpiry", euserinformation.Expiry, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceOfRelease", euserinformation.Placeofreleaseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceOfResidence", euserinformation.Placeofresidenceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoPlaceOfResidenceVillage", euserinformation.Placeofresidencevillageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserInfoUIP", euserinformation.Userimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UserInfoSSN", euserinformation.Ssn, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UserInfoBloodType", euserinformation.Bloodtypeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EUserInformation_Package.UpdateUserInformation", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
