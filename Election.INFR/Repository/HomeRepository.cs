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
    public class HomeRepository : ISharedRepository<Ehome>
    {
        private readonly IDbContext _dbContext;

        public HomeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Ehome Create(Ehome ehome)
        {
            var p = new DynamicParameters();
            p.Add("HomeImg1", ehome.Homeimage1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeImg2", ehome.Homeimage2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeImg3", ehome.Homeimage3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeTi1", ehome.Hometitle1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeTi2", ehome.Hometitle2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeTi3", ehome.Hometitle3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EHOME_Package.CreateHome", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("HomeID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EHOME_Package.DeleteHome", p, commandType: CommandType.StoredProcedure);
        }

        public List<Ehome> GetAll()
        {
            IEnumerable<Ehome> result = _dbContext.Connection.Query<Ehome>("EHOME_Package.GetAllHome", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ehome GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("HomeID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Ehome> result = _dbContext.Connection.Query<Ehome>("EHOME_Package.GetHomeById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Ehome Update(Ehome ehome)
        {
            var p = new DynamicParameters();
            p.Add("HomeID", ehome.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("HomeImg1", ehome.Homeimage1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeImg2", ehome.Homeimage2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeImg3", ehome.Homeimage3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeTi1", ehome.Hometitle1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeTi2", ehome.Hometitle2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HomeTi3", ehome.Hometitle3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("EHOME_Package.UpdateHome", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }
    }
}
