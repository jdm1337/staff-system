using StaffSystem.Core.ProjectAggregate.Identity;
using System.ComponentModel.DataAnnotations;

namespace StaffSystem.Web.Models
{
    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public Departments Department { get; set; } = 0;
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public Positions Position { get; set; } = 0;

        // Director special data
        public string? CompanyName { get; set; }

        // Department Head special data
        public string? DepartmentName { get; set; }

        // Controller special data: ProjectName - information about the project managed by the controller
        public string? ProjectName { get; set; }

        // Worker special data
        public string? ControllerName { get; set; }
    }
}
