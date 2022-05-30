using StaffSystem.Core.Interfaces;
using StaffSystem.Core.ProjectAggregate.Identity;
using StaffSystem.Infrastructure.Data;


namespace StaffSystem.Services
{
    public class UserFilterService : IUserFilterService
    {
        private readonly AppDbContext _context;
        public UserFilterService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<User>> FilterAsync(int department, int position)
        {
            var users = _context.Users
                .Select(u => new User()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    Surname = u.Surname,
                    Patronymic = u.Patronymic,
                    BirthDay = u.BirthDay,
                    Position = u.Position,
                    Department = u.Department
                });

            if(department > -1)
            {
                users = users.Where(u => ((int)u.Department) == department);
            }
            if(position > -1)
            {
                users = users.Where(u =>((int)u.Position) == position);
            }
            return users;
        }
    }
}
