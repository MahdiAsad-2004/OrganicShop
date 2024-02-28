using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{
    public class FaqService : IFaqService
    {
        #region ctor

        private readonly IFaqRepository _FaqRepository;
        public Message<Faq> _Message { init; get; } = new Message<Faq>();

        public FaqService(IFaqRepository FaqRepository)
        {
            _FaqRepository = FaqRepository;
        }

        #endregion


        public async Task<PageDto<Faq, FaqListDto, byte>> GetAll(FilterFaqDto filter, SortFaqDto sort, PagingDto paging)
        {
            var query = _FaqRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.QuestionText != null)
                query = query.Where(q => EF.Functions.Like(q.QuestionText, $"%{filter.QuestionText}%"));

            if (filter.AnswerText != null)
                query = query.Where(q => EF.Functions.Like(q.AnswerText, $"%{filter.AnswerText}%"));

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            #endregion

            PageDto<Faq, FaqListDto, byte> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateFaqDto create)
        {
            Faq Faq = create.ToModel();
            await _FaqRepository.Add(Faq,1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateFaqDto update)
        {
            Faq? Faq = await _FaqRepository.GetAsTracking(update.Id);
            
            if (Faq == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _FaqRepository.Update(update.ToModel(Faq), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(byte delete)
        {

            Faq? Faq = await _FaqRepository.GetAsTracking(delete);

            if (Faq == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _FaqRepository.SoftDelete(Faq, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
