using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class FacultyLoad
{
    public int LoadId { get; set; }

    public int FacultyId { get; set; }

    public int SubjectId { get; set; }

    public int SectionId { get; set; }

    public int SchoolYearId { get; set; }

    public virtual Faculty Faculty { get; set; } = null!;

    public virtual SchoolYear SchoolYear { get; set; } = null!;

    public virtual Section Section { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
