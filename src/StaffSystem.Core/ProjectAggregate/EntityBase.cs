using StaffSystem.Core.Interfaces;


namespace StaffSystem.SharedKernel
{
     public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
