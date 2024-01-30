using OrganicShop.Domain.Dtos.ContactUsDtos;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IContactUsService
    {
        Task<EntityResultUpdate> Update(UpdateContactUsDto update);
       
        Task<UpdateContactUsDto> Get();
    }
}
