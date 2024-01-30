namespace OrganicShop.Domain.Dtos.FaqDtos
{
    public record CreateFaqDto
    {
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }




}
