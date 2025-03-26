using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class LowLevelDepartment
{
    public int IdDepartmentlow { get; set; }

    public string? NameDepartmentlow { get; set; }

    public string? DescriptionDepartmentlow { get; set; }

    public int? ParentDepartmentlow { get; set; }

    public virtual MediumLevelDepartment? ParentDepartmentlowNavigation { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
