using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class EventType
{
    public int IdTypeEvent { get; set; }

    public string? NameTypeName { get; set; }

    public virtual ICollection<EventList> EventLists { get; set; } = new List<EventList>();
}
