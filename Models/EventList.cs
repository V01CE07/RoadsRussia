using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class EventList
{
    public int IdEvent { get; set; }

    public string? NameEvent { get; set; }

    public int? TypeEvent { get; set; }

    public string? DescriptionEvent { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual EventType? TypeEventNavigation { get; set; }

    public virtual ICollection<WorkCalendar> WorkCalendars { get; set; } = new List<WorkCalendar>();
}
