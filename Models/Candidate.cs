using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class Candidate
{
    public int Id { get; set; }

    public string? NameCandidate { get; set; }

    public string? PhonenumberCandidate { get; set; }

    public string? EmailCandidate { get; set; }

    public string? SummaryCandidate { get; set; }

    public int? HrCandidate { get; set; }

    public DateTime? DateInterview { get; set; }

    public int? RequiredPosition { get; set; }

    public virtual JobList? RequiredPositionNavigation { get; set; }
}
