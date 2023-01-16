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
    public class CategoryRepository : ISharedRepository<Ecategory> , ICategoryRepository
    {
        private readonly IDbContext _dbContext;

        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Ecategory> GetAll()
        {
            IEnumerable<Ecategory> result = _dbContext.Connection.Query<Ecategory>("ECategory_Package.GetAllCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ecategory GetById(int id)
        {
           
            var p = new DynamicParameters();
            p.Add("CategoryID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Ecategory> result = _dbContext.Connection.Query<Ecategory>("ECategory_Package.GetCategoryById", p , commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Ecategory Create(Ecategory ecategory)
        {
            var p = new DynamicParameters();
            p.Add("CatName", ecategory.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ECategory_Package.CreateCategory", p, commandType: CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("CategoryID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ECategory_Package.DeleteCategory", p, commandType: CommandType.StoredProcedure);
        }

        public Ecategory Update(Ecategory ecategory)
        {
            var p = new DynamicParameters();
            p.Add("CategoryID", ecategory.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CatName", ecategory.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ECategory_Package.UpdateCategory" , p , commandType:CommandType.StoredProcedure);
            int id = p.Get<int>("result");
            return GetById(id);
        }

        public List<Ecategory> Search(string name)
        {
            var p = new DynamicParameters();
            p.Add("Name", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Ecategory> result = _dbContext.Connection.Query<Ecategory>("ECategory_Package.SearchCategoryName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
