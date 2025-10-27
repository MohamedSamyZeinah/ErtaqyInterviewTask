using Ertaqy_Task.BLL.Contract;
using Ertaqy_Task.BLL.DTOs;
using Ertaqy_Task.DAL.Models;
using Ertaqy_Task.DAL.Repository;
using System.Data;

namespace Ertaqy_Task.BLL.Manager
{
    public class ServiceProviderManger : IServiceProviderService
    {
        #region Fields
        private readonly IServiceProviderRepository _serviceProviderRepository;
        #endregion

        #region Constructor
        public ServiceProviderManger(IServiceProviderRepository serviceProviderRepository)
        {
            _serviceProviderRepository = serviceProviderRepository;
        }
        #endregion

        #region Functions Implementations
        public int Create(ServiceProviderDto providerDto)
        {
            // map Dto => Entity
            var serviceProvider = new ServiceProvider
            {
                Id = providerDto.Id,
                Name = providerDto.ProviderName,
                Email = providerDto.ProviderEmail,
                PhoneNumber = providerDto.ProviderPhoneNumber,
                Address = providerDto.ProviderAddress
            };
            return _serviceProviderRepository.Insert(serviceProvider);
        }

        //public int Delete(int id)
        //{
        //    return _serviceProviderRepository.Delete(id);
        //}

        public IEnumerable<ServiceProviderDto> GetAll()
        {
            var providers = _serviceProviderRepository.GetAll();
            var list = new List<ServiceProviderDto>();
            foreach (DataRow row in providers.Rows)
            {
                list.Add(new ServiceProviderDto
                {
                    Id = (int)row["Id"],
                    ProviderName = row["Name"].ToString(),
                    ProviderEmail = row["Email"].ToString(),
                    ProviderPhoneNumber = row["PhoneNumber"].ToString(),
                    ProviderAddress = row["Address"].ToString(),
                });
            }
            return list;
        }

        public ServiceProviderDto GetById(int id)
        {
            var provider = _serviceProviderRepository.GetById(id);
            var providerDto = new ServiceProviderDto
            {
                Id = (int)provider["Id"],
                ProviderName = provider["Name"].ToString(),
                ProviderEmail = provider["Email"].ToString(),
                ProviderPhoneNumber = provider["PhoneNumber"].ToString(),
                ProviderAddress = provider["Address"].ToString(),
            };
            return providerDto;
        }

        public int Update(ServiceProvider provider)
        {
            return _serviceProviderRepository.Update(provider);
        }
        #endregion
    }
}
