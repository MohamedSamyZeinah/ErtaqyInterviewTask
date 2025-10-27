using Ertaqy_Task.DAL.DataAccess;
using Ertaqy_Task.DAL.Models;
using Ertaqy_Task.DAL.Repository.Generic;

namespace Ertaqy_Task.DAL.Repository
{
    public class ServiceProviderRepository : GenericRepository<ServiceProvider>, IServiceProviderRepository
    {
        public ServiceProviderRepository(AppDb appDb) : base(appDb) { }
    }
}
