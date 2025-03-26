using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class MediumLevelDepartment
{
    public int IdDepartmentmedium { get; set; }

    public string NameDepartmentmedium { get; set; } = null!;

    public string? DescriptionDepartmentmedium { get; set; }

    public int ParentDepartmentmedium { get; set; }

    public virtual ICollection<LowLevelDepartment> LowLevelDepartments { get; set; } = new List<LowLevelDepartment>();

    public virtual HighLevelDepartment ParentDepartmentmediumNavigation { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
