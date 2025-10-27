using Ertaqy_Task.BLL.DTOs;
using Ertaqy_Task.DAL.Models;

namespace Ertaqy_Task.BLL.Contract
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> GetAll();
        public ProductDto GetById(int id);
        public int Create(ProductDto productDto);
        public int Update(Product product);
        //public int Delete(int id);


        public IEnumerable<ProductDto> Filter(decimal? minPrice, decimal? maxPrice, DateTime? dateFrom, DateTime? dateTo, int? providerId, string? search);
    }
}
