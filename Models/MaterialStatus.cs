using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class MaterialStatus
{
    public int IdStatusMaterial { get; set; }

    public string? NameStatusMaterial { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
