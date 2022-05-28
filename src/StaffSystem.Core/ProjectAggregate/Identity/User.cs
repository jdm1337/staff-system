using Microsoft.AspNetCore.Identity;
using StaffSystem.SharedKernel;
using StaffSystem.SharedKernel.Interfaces;

namespace StaffSystem.Core.ProjectAggregate.Identity
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }

        // Director special data
        public string CompanyName { get; set; }

        // Department Head special data
        public string DepartmentName { get; set; }

        // Controller special data: ProjectName - information about the project managed by the controller
        public string ProjectName { get; set; }

        // Worker special data
        public string ControllerName { get; set; }
        

        public User() : base() { }
    }
}
