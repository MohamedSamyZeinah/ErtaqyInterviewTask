using Ertaqy_Task.BLL.DTOs;
using Ertaqy_Task.DAL.Models;

namespace Ertaqy_Task.BLL.Contract
{
    public interface IServiceProviderService
    {
        public IEnumerable<ServiceProviderDto> GetAll();
        public ServiceProviderDto GetById(int id);
        public int Create(ServiceProviderDto providerDto);
        public int Update(ServiceProvider provider);
        //public int Delete(int id);
    }
}
