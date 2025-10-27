using Ertaqy_Task.DAL.DataAccess;
using Ertaqy_Task.DAL.Models;
using Ertaqy_Task.DAL.Repository.Generic;
using System.Data;
using System.Text;

namespace Ertaqy_Task.DAL.Repository.ProductRepo
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        #region Fields
        private readonly AppDb _appDb;
        #endregion

        #region Constructor
        public ProductRepository(AppDb appDb) : base(appDb)
        {
            _appDb = appDb;
        }
        #endregion

        #region Methods
        public DataTable Filter(decimal? minPrice, decimal? maxPrice, DateTime? dateFrom, DateTime? dateTo, int? providerId, string? search)
        {
            StringBuilder query = new();

            query.AppendLine(@"
                                Select p.Id, p.ProductName, p.Price, p.CreationDate, s.Name as ServiceProviderName
                                from Products p
                                Left Join ServiceProviders s 
                                On p.ProviderId = s.Id
                                where 1 = 1
                                ");

            var parameters = new Dictionary<string, object>();

            if (minPrice.HasValue)
            {
                query.AppendLine(" and p.Price >= @minPrice");
                parameters.Add("@minPrice", minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query.AppendLine(" and p.Price <= @maxPrice");
                parameters.Add("@maxPrice", maxPrice.Value);
            }

            if (dateFrom.HasValue)
            {
                query.AppendLine(" and p.CreationDate >= @dateFrom");
                parameters.Add("@dateFrom", dateFrom.Value.Date);
            }

            if (dateTo.HasValue)
            {
                query.AppendLine(" and p.CreationDate <= @dateTo");
                parameters.Add("@dateTo", dateTo.Value.Date.AddDays(1).AddTicks(-1));
            }

            if (providerId.HasValue)
            {
                query.AppendLine(" and p.ProviderId = @providerId");
                parameters.Add("@providerId", providerId.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {

                query.AppendLine(" AND (P.ProductName LIKE @search OR S.Name LIKE @search)");
                parameters.Add("@search", $"%{search.Trim()}%");
            }

            query.AppendLine(" ORDER BY P.CreationDate DESC");

            return _appDb.ExecuteQuery(query.ToString(), parameters);
        }
        #endregion
    }
}
