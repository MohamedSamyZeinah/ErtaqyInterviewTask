using Ertaqy_Task.BLL.DTOs;

namespace Ertaqy_Task.BLL.Contract
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> GetAll();
        public int Create(ProductDto productDto);

        public IEnumerable<ProductDto> Filter(decimal? minPrice, decimal? maxPrice, DateTime? dateFrom, DateTime? dateTo, int? providerId, string? search);
    }
}
