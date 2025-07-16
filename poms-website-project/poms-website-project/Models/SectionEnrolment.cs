using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class SectionEnrolment
{
    public int EnrolId { get; set; }

    public int LearnerId { get; set; }

    public int SectionId { get; set; }

    public int SchoolYearId { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual SchoolYear SchoolYear { get; set; } = null!;

    public virtual Section Section { get; set; } = null!;
}
