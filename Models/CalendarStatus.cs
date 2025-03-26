using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class CalendarStatus
{
    public int IdStatusCalendar { get; set; }

    public string? NameStatusCalendar { get; set; }

    public virtual ICollection<WorkCalendar> WorkCalendars { get; set; } = new List<WorkCalendar>();
}
