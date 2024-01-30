namespace OrganicShop.Domain.Entities.Base
{
    public class SoftDelete
    {
        public bool IsDelete { get; set; }
        public DateTime? DalateDate { get; set; }



        public SoftDelete()
        {
    
        }

        public SoftDelete(bool newEntity)
        {
            IsDelete = false;
            DalateDate = null;
        }

    }

}
