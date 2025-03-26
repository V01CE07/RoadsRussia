using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class MaterialArea
{
    public int IdAreaMaterial { get; set; }

    public string? NameAreaMaterial { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
