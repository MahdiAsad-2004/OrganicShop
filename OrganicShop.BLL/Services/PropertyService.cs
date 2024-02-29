using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;

namespace OrganicShop.BLL.Services
{
    public class PropertyService : IPropertyService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IPropertyRepository _PropertyRepository;
        public Message<Property> _Message { init; get; } = new Message<Property>();

        public PropertyService(IMapper mapper,IPropertyRepository PropertyRepository)
        {
            _Mapper = mapper;
            this._PropertyRepository = PropertyRepository;
        }

        #endregion


        

        public async Task<PageDto<Property,PropertyListDto,int>> GetAll(FilterPropertyDto filter, SortPropertyDto sort, PagingDto paging)
        {
            var query = _PropertyRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);
            
            if (filter.IsBase != null)
                query = query.Where(q => q.IsBase == filter.IsBase.Value);

            #endregion

            #region sort

            query = sort.ApplyBaseSort(query);

            if (sort.Priority == true) query = query.OrderBy(o => o.Priority); 
            if (sort.Priority == false) query = query.OrderByDescending(o => o.Priority);

            #endregion


            PageDto<Property, PropertyListDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query,paging).Select(a => _Mapper.Map<PropertyListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreatePropertyDto create)
        {
            Property Property = _Mapper.Map<Property>(create);

            Property.IsBase = true;
            Property.Value = string.Empty;

            await _PropertyRepository.Add(Property,1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdatePropertyDto update)
        {
            Property? Property = await _PropertyRepository.GetAsTracking(update.Id);
            
            if (Property == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _PropertyRepository.Update(_Mapper.Map<Property>(update), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(int delete)
        {
            Property? Property = await _PropertyRepository.GetAsTracking(delete);

            if (Property == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _PropertyRepository.SoftDelete(Property, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
