using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{
    public class PictureService : IPictureService
    {
        #region ctor

        private readonly IPictureRepository _PictureRepository;
        public Message<Picture> _Message { init; get; } = new Message<Picture>();

        public PictureService(IPictureRepository PictureRepository)
        {
            _PictureRepository = PictureRepository;
        }

        #endregion



        public async Task<PageDto<Picture , PictureListDto,long>> GetAll(FilterPictureDto filter , SortPictureDto sort , PagingDto paging)
        {
            var query = _PictureRepository.GetQueryable();

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

            //await _PictureRepository.Add(Picture, 1);
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

            //await _PictureRepository.Update(update.ToModel(Picture), 1);
            //return EntityResult.success;



            throw new NotImplementedException();
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            Picture? Picture = await _PictureRepository.GetAsTracking(delete);

            if (Picture == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.SuccessDelete());

            await _PictureRepository.SoftDelete(Picture, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
