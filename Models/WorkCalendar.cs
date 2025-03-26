using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class WorkCalendar
{
    public int IdCalendar { get; set; }

    public int? WorkerCalendar { get; set; }

    public int? EventCalendar { get; set; }

    public int? ChiefCalendar { get; set; }

    public int? StatusCalendar { get; set; }

    public DateTime? StartCalendar { get; set; }

    public DateTime? EndCalendar { get; set; }

    public virtual EventList? EventCalendarNavigation { get; set; }

    public virtual CalendarStatus? StatusCalendarNavigation { get; set; }
}
