using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class HighLevelDepartment
{
    public int IdDepartmenthigh { get; set; }

    public string? NameDepartmenthigh { get; set; }

    public string? DescriptionDepartmenthigh { get; set; }

    public virtual ICollection<MediumLevelDepartment> MediumLevelDepartments { get; set; } = new List<MediumLevelDepartment>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
