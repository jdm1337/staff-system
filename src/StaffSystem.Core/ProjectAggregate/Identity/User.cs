using StaffSystem.SharedKernel;

namespace StaffSystem.Core.ProjectAggregate.Identity
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public Departments Department { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public Positions Position { get; set; }

        // Director special data
        public string? CompanyName { get; set; }

        // Department Head special data - department name managed by Head
        public string? DepartmentName { get; set; }

        // Controller special data: ProjectName - information about the project managed by the controller
        public string? ProjectName { get; set; }

        // Worker special data
        public string? ControllerName { get; set; }
        

        public User() : base() { }
    }
}
