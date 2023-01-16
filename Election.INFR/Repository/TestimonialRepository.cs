using Dapper;
using Election.CORE.Common;
using Election.CORE.Data;
using Election.CORE.DTO;
using Election.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Election.INFR.Repository
{
    public class TestimonialRepository : ISharedRepository<Etestimonial> ,ITestimonialRepository
    {
        private readonly IDbContext _dbContext;

        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Etestimonial Create(Etestimonial etestimonial)
        {
            var p = new DynamicParameters();
            p.Add("NameTest", etestimonial.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EmailTest", etestimonial.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("acceptStatusTest", etestimonial.Acceptstatus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MessageTest", etestimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IdHome", etestimonial.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IdUser", etestimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ETESTIMONIAL_Package.CreateTESTIMONIAL", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("TstimonalId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ETESTIMONIAL_Package.DeleteTESTIMONIAL", p, commandType: CommandType.StoredProcedure);
        }

        public List<Etestimonial> GetAll()
        {
            IEnumerable<Etestimonial> result = _dbContext.Connection.Query<Etestimonial>("ETESTIMONIAL_Package.GetAllTESTIMONIAL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Etestimonial GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("TstimonalId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Etestimonial> result = _dbContext.Connection.Query<Etestimonial>("ETESTIMONIAL_Package.GetTESTIMONIALById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<HomeTestimonial> homeTestimonials()
        {
            IEnumerable<HomeTestimonial> result = _dbContext.Connection.Query<HomeTestimonial>("ETESTIMONIAL_Package.HomeTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Etestimonial Update(Etestimonial etestimonial)
        {
            var p = new DynamicParameters();
            p.Add("TstimonalId", etestimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NameTest", etestimonial.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EmailTest", etestimonial.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("acceptStatusTest", etestimonial.Acceptstatus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MessageTest", etestimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ETESTIMONIAL_Package.UpdateTESTIMONIAL", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
