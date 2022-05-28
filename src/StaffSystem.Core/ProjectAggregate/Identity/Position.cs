using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffSystem.Core.ProjectAggregate.Identity
{
    public enum Position
    {
        [Display(Name = "Директор")]
        Director,

        [Display(Name = "Руководитель подразделения")]
        DepartmentHead,

        [Display(Name = "Контроллер")]
        Controller,

        [Display(Name = "Рабочий")]
        Worker
    }
}
