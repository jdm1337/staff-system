using System.ComponentModel.DataAnnotations;


namespace StaffSystem.Core.ProjectAggregate.Identity
{
    public enum Departments
    {
        [Display(Name = "Тех. поддержка")]
        Support=1,

        [Display(Name = "Разработка ПО")]
        SoftwareDevelopment=2,

        [Display(Name = "Анализ данных")]
        DataAnalysis=3,

        [Display(Name = "Менеджмент")]
        Management=4
    }
}
