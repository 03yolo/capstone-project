using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectCode { get; set; } = null!;

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<AssessmentGrade> AssessmentGrades { get; set; } = new List<AssessmentGrade>();

    public virtual ICollection<FacultyLoad> FacultyLoads { get; set; } = new List<FacultyLoad>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
