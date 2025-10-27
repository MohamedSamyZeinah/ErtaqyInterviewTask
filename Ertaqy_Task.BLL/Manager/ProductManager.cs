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

        //public int Delete(int id)
        //{
        //    return _productRepository.Delete(id);
        //}

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

        public ProductDto GetById(int id)
        {
            var product = _productRepository.GetById(id);
            var ProductDto = new ProductDto
            {
                Id = (int)product["Id"],
                PrdctName = product["ProductName"].ToString(),
                PrdctPrice = (decimal)product["Price"],
                CreationDate = (DateTime)product["CreationDate"],
                ProviderId = (int)product["ProviderId"],
            };
            return ProductDto;
        }

        public int Update(Product product)
        {
            return _productRepository.Update(product);
        }
        #endregion

    }
}
