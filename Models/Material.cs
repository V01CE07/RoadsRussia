using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class Material
{
    public int IdMaterial { get; set; }

    public string? NameMaterial { get; set; }

    public DateTime? CreateDateMaterial { get; set; }

    public DateTime? EditDateMaterial { get; set; }

    public int? StatusMaterial { get; set; }

    public int? TypeMaterial { get; set; }

    public int? AreaMaterial { get; set; }

    public int? AuthorMaterial { get; set; }

    public int? EventMaterial { get; set; }

    public virtual MaterialArea? AreaMaterialNavigation { get; set; }

    public virtual EventList? EventMaterialNavigation { get; set; }

    public virtual MaterialStatus? StatusMaterialNavigation { get; set; }

    public virtual MaterialType? TypeMaterialNavigation { get; set; }
}
