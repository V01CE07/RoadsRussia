using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class CabinetList
{
    public int IdCabinet { get; set; }

    public string NumberCabinet { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
