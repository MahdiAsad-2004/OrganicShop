using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Response;
using OrganicShop.Domain.Dtos.BasketDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;

namespace OrganicShop.BLL.Services
{
    public class BasketService : Service<Basket> , IBasketService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IBasketRepository _BasketRepository;

        public BasketService(IApplicationUserProvider provider,IMapper mapper,IBasketRepository BasketRepository) : base(provider)
        {
            _Mapper = mapper;
            _BasketRepository = BasketRepository;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<Basket, BasketListDto, long>>> GetAll(FilterBasketDto? filter = null, PagingDto? paging = null)
        {
            var query = _BasketRepository.GetQueryable();

            if (filter == null) filter = new FilterBasketDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Basket, BasketListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<BasketListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);


            return new ServiceResponse<PageDto<Basket, BasketListDto, long>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateBasketDto create)
        {
            if (await _BasketRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 2)
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.MaxCreate(2));

            Basket Basket = _Mapper.Map<Basket>(create);

            await _BasketRepository.Add(Basket,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateBasketDto update)
        {
            Basket? Basket = await _BasketRepository.GetAsTracking(update.Id);
            
            if (Basket == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _BasketRepository.Update(_Mapper.Map<Basket>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            Basket? Basket = await _BasketRepository.GetAsTracking(delete);

            if (Basket == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _BasketRepository.SoftDelete(Basket, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }




    }
}
