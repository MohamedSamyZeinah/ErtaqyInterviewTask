using Ertaqy_Task.BLL.Contract;
using Ertaqy_Task.BLL.DTOs;
using Ertaqy_Task.DAL.Models;
using Ertaqy_Task.DAL.Repository.ProductRepo;
using System.Data;

namespace Ertaqy_Task.BLL.Manager
{
    public class ProductManager : IProductService
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Functions Implementation
        public int Create(ProductDto productDto)
        {
            var product = new Product
            {
                ProductName = productDto.PrdctName,
                Price = productDto.PrdctPrice,
                ProviderId = productDto.ProviderId
            };
            return _productRepository.Insert(product);
        }

        public IEnumerable<ProductDto> Filter(decimal? minPrice, decimal? maxPrice, DateTime? dateFrom, DateTime? dateTo, int? providerId, string? search)
        {
            var prdt = _productRepository.Filter(minPrice, maxPrice, dateFrom, dateTo, providerId, search);
            var productLsit = new List<ProductDto>();
            foreach (DataRow row in prdt.Rows)
            {
                productLsit.Add(new ProductDto
                {
                    Id = (int)row["Id"],
                    PrdctName = row["ProductName"].ToString(),
                    PrdctPrice = (decimal)row["Price"],
                    CreationDate = (DateTime)row["CreationDate"],
                    ProviderName = row["ServiceProviderName"].ToString(),
                    //ProviderId = (int)row["ProviderId"]
                    ProviderId = row.Table.Columns.Contains("ProviderId") ? Convert.ToInt32(row["ProviderId"]) : 0
                });
            }
            return productLsit;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _productRepository.GetAll();
            List<ProductDto> list = new();
            foreach (DataRow row in products.Rows)
            {
                list.Add(new ProductDto
                {
                    Id = (int)row["Id"],
                    PrdctName = row["ProductName"].ToString(),
                    PrdctPrice = (decimal)row["Price"],
                    CreationDate = (DateTime)row["CreationDate"],
                    ProviderId = (int)row["ProviderId"],
                });
            }
            return list;
        }

        #endregion

    }
}
