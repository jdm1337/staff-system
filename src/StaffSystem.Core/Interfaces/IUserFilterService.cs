using StaffSystem.Core.ProjectAggregate.Identity;

namespace StaffSystem.Core.Interfaces
{
    public interface IUserFilterService
    {
        Task<IQueryable<User>> FilterAsync(int department, int position);
    }
}
