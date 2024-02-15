using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.Response
{
    public class ServiceResponse
    {
        public EntityResult Result { get; set; }
        public string Message { get; set; }
       



        public ServiceResponse(EntityResult result,string message)
        {
            Result = result;
            Message = message;
        }
    }
}
