
using System.ComponentModel.DataAnnotations;


namespace StaffSystem.Core.ProjectAggregate.Identity
{
    public enum Positions
    {
        [Display(Name = "Директор")]
        Director = 1,

        [Display(Name = "Руководитель подразделения")]
        DepartmentHead = 2,

        [Display(Name = "Контроллер")]
        Controller = 3,

        [Display(Name = "Младший сотрудник")]
        Worker = 4
    }
}
