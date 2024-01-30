using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public static class FaqMappers
    {
        public static FaqListDto ToListDto(this Faq Faq)
        {
            return new FaqListDto
            {
                Id = Faq.Id,
                QuestionText = Faq.QuestionText,
                AnswerText = Faq.AnswerText,
            };
        }

        public static Faq ToModel(this CreateFaqDto create)
        {
            return new Faq()
            {
                QuestionText = create.QuestionText,
                AnswerText = create.AnswerText,
            };
        }

        public static Faq ToModel(this UpdateFaqDto update, Faq Faq)
        {
            Faq.QuestionText = update.QuestionText;
            Faq.AnswerText = update.AnswerText;
            return Faq;
        }









    }
}
