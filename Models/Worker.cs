using System;
using System.Collections.Generic;

namespace calendar.Models;

public partial class Worker
{
    public int IdWorker { get; set; }

    public string NameWorker { get; set; } = null!;

    public int JobPositionWorker { get; set; }

    public int HighDepartmentWorker { get; set; }

    public int? MediumDepartmentWorker { get; set; }

    public int? LowDepartmentWorker { get; set; }

    public DateTime? DateOfBirthWorker { get; set; }

    public string? PhonenumberWorker { get; set; }

    public string? EmailWorker { get; set; }

    public int? GenderWorker { get; set; }

    public int? CabinetWorker { get; set; }

    public bool? IsfiredWorker { get; set; }

    public virtual CabinetList? CabinetWorkerNavigation { get; set; }

    public virtual Gender? GenderWorkerNavigation { get; set; }

    public virtual HighLevelDepartment HighDepartmentWorkerNavigation { get; set; } = null!;

    public virtual JobList JobPositionWorkerNavigation { get; set; } = null!;

    public virtual LowLevelDepartment? LowDepartmentWorkerNavigation { get; set; }

    public virtual MediumLevelDepartment? MediumDepartmentWorkerNavigation { get; set; }
}
