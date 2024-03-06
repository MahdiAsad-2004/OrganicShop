using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.IProviders;

namespace OrganicShop.BLL.Services
{
    public class PictureService : Service<Picture>, IPictureService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IPictureRepository _PictureRepository;

        public PictureService(IApplicationUserProvider provider,IMapper mapper,IPictureRepository PictureRepository) : base(provider)
        {
            _Mapper = mapper;
            _PictureRepository = PictureRepository;
        }

        #endregion



        public async Task<PageDto<Picture , PictureListDto,long>> GetAll(FilterPictureDto? filter = null , SortPictureDto? sort = null , PagingDto? paging = null)
        {
            var query = _PictureRepository.GetQueryable();

            if (filter == null) filter = new FilterPictureDto();
            if (sort == null) sort = new SortPictureDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Name != null)
                query = query.Where(q => EF.Functions.Like(q.Name, $"%{filter.Name}%"));

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Name == true) query = query.OrderBy(o => o.Name);
            if (sort.Name == false) query = query.OrderByDescending(o => o.Name);

            if (sort.Size == true) query = query.OrderBy(o => o.SizeMB);
            if (sort.Size == false) query = query.OrderByDescending(o => o.SizeMB);

            #endregion

            PageDto<Picture, PictureListDto,long> pageDto = new();
            //pageDto.List = pageDto.SetPaging(query , paging).Select(a => a.ToListDto()).ToList();
            //pageDto.Pager = pageDto.SetPager(query, paging);


            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreatePictureDto create)
        {
            //Picture Picture = create.ToModel();

            //if (await _PictureRepository.GetQueryable().AnyAsync(a => a.Title.Contains(create.Title, StringComparison.OrdinalIgnoreCase)))
            //    return EntityResult.EntityExist;

            //await _PictureRepository.Add(Picture, _AppUserProvider.User.Id);
            //return EntityResult.success;




            throw new NotImplementedException();
        }



        public async Task<ServiceResponse> Update(UpdatePictureDto update)
        {
            //Picture? Picture = await _PictureRepository.GetAsTracking(update.Id);

            //if (Picture == null)
            //    return EntityResult.NotFound;

            //if (await _PictureRepository.GetQueryable().AnyAsync(a => a.Title.Contains(update.Title, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
            //    return EntityResult.EntityExist;

            //await _PictureRepository.Update(update.ToModel(Picture), _AppUserProvider.User.Id);
            //return EntityResult.success;



            throw new NotImplementedException();
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            Picture? Picture = await _PictureRepository.GetAsTracking(delete);

            if (Picture == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.SuccessDelete());

            await _PictureRepository.SoftDelete(Picture, _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
