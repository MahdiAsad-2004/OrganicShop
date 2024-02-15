using OrganicShop.Domain.Dtos.ContactUsDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IContactUsService : IService<ContactUs>
    {
        Task<ServiceResponse> Update(UpdateContactUsDto update);
       
        Task<UpdateContactUsDto> Get();
    }
}
