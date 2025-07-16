using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int LearnerId { get; set; }

    public DateOnly SchoolDate { get; set; }

    public bool IsPresent { get; set; }

    public virtual Learner Learner { get; set; } = null!;
}
