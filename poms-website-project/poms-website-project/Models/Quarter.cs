using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class Quarter
{
    public int QuarterId { get; set; }

    public int SchoolYearId { get; set; }

    public byte QuarterNo { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<AssessmentGrade> AssessmentGrades { get; set; } = new List<AssessmentGrade>();

    public virtual SchoolYear SchoolYear { get; set; } = null!;
}
