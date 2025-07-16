using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class Section
{
    public int SectionId { get; set; }

    public string SectionName { get; set; } = null!;

    public byte GradeLevel { get; set; }

    public virtual ICollection<FacultyLoad> FacultyLoads { get; set; } = new List<FacultyLoad>();

    public virtual ICollection<SectionEnrolment> SectionEnrolments { get; set; } = new List<SectionEnrolment>();
}
