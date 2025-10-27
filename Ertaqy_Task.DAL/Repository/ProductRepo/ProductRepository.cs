using Ertaqy_Task.DAL.DataAccess;
using Ertaqy_Task.DAL.Models;
using Ertaqy_Task.DAL.Repository.Generic;

namespace Ertaqy_Task.DAL.Repository.ProductRepo
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDb appDb) : base(appDb) { }
    }
}
