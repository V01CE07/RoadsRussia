using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class JobList
{
    public int Id { get; set; }

    public string Jobname { get; set; } = null!;

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
