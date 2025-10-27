using Ertaqy_Task.DAL.Models;
using Ertaqy_Task.DAL.Repository.Generic;
using System.Data;

namespace Ertaqy_Task.DAL.Repository.ProductRepo
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public DataTable Filter(decimal? minPrice, decimal? maxPrice, DateTime? dateFrom, DateTime? dateTo, int? providerId, string? search);
    }
}
