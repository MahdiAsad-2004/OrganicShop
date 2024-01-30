using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;

namespace OrganicShop.BLL.Services
{
    public class PictureService : IPictureService
    {
        #region ctor

        private readonly IPictureRepository _PictureRepository;

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
            
            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreatePictureDto create)
        {
            //Picture Picture = create.ToModel();

            //if (await _PictureRepository.GetQueryable().AnyAsync(a => a.Title.Contains(create.Title, StringComparison.OrdinalIgnoreCase)))
            //    return EntityResultCreate.EntityExist;

            //await _PictureRepository.Add(Picture, 1);
            //return EntityResultCreate.success;




            throw new NotImplementedException();
        }



        public async Task<EntityResultUpdate> Update(UpdatePictureDto update)
        {
            //Picture? Picture = await _PictureRepository.GetAsTracking(update.Id);

            //if (Picture == null)
            //    return EntityResultUpdate.NotFound;

            //if (await _PictureRepository.GetQueryable().AnyAsync(a => a.Title.Contains(update.Title, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
            //    return EntityResultUpdate.EntityExist;

            //await _PictureRepository.Update(update.ToModel(Picture), 1);
            //return EntityResultUpdate.success;



            throw new NotImplementedException();
        }



        public async Task<EntityResultDelete> Delete(long delete)
        {
            Picture? Picture = await _PictureRepository.GetAsTracking(delete);

            if (Picture == null)
                return EntityResultDelete.NotFound;

            await _PictureRepository.SoftDelete(Picture, 1);
            return EntityResultDelete.success;
        }
    }
}
