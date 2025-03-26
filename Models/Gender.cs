using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class Gender
{
    public int IdGender { get; set; }

    public string? NameGender { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
