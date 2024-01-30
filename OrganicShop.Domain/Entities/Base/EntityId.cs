namespace OrganicShop.Domain.Entities.Base
{
    public abstract class EntityId<Key> : IAggregateRoot where Key : struct 
    {
        public  Key Id { get; set; }
        public BaseEntity BaseEntity { get; set; }
        public SoftDelete SoftDelete { get; set; }

        //public BaseEntity BaseEntity { get; set; } = new BaseEntity() { CreateDate = DateTime.Now, LastModified = DateTime.Now , IsActive = true};
        //public SoftDelete SoftDelete { get; set; } = new SoftDelete() { IsDelete = false, DalateDate = null};
    }

}
