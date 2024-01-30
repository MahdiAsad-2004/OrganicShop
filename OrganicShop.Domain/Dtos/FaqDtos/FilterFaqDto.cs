using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.FaqDtos
{
    public class FilterFaqDto : BaseFilterDto<Entities.Faq, byte>
    {
        public string? QuestionText { get; set; }
        public string? AnswerText { get; set; }
    }




}
