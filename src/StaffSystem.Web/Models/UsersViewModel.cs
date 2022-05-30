using cloudscribe.Pagination.Models;
using StaffSystem.Core.ProjectAggregate.Identity;

namespace StaffSystem.Web.Models
{
    public class UsersViewModel
    {
        public PagedResult<User> Users { get; set; }
    }
}
