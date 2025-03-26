using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class MaterialType
{
    public int IdTypeMaterial { get; set; }

    public string? NameTypeMaterial { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
