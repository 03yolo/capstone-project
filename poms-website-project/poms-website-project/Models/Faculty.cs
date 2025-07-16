using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class Faculty
{
    public int FacultyId { get; set; }

    public string EmployeeNo { get; set; } = null!;

    public string? Designation { get; set; }

    public virtual ICollection<AssessmentGrade> AssessmentGrades { get; set; } = new List<AssessmentGrade>();

    public virtual ICollection<FacultyLoad> FacultyLoads { get; set; } = new List<FacultyLoad>();

    public virtual User FacultyNavigation { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
