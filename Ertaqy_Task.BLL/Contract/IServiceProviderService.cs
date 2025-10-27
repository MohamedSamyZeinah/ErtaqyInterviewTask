using Ertaqy_Task.BLL.DTOs;

namespace Ertaqy_Task.BLL.Contract
{
    public interface IServiceProviderService
    {
        public IEnumerable<ServiceProviderDto> GetAll();
        public int Create(ServiceProviderDto providerDto);

    }
}
