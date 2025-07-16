using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class Learner
{
    public int LearnerId { get; set; }

    public string Lrn { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public byte GradeLevel { get; set; }

    public virtual ICollection<AssessmentGrade> AssessmentGrades { get; set; } = new List<AssessmentGrade>();

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual User LearnerNavigation { get; set; } = null!;

    public virtual ICollection<ParentLearner> ParentLearners { get; set; } = new List<ParentLearner>();

    public virtual ICollection<SchoolForm> SchoolForms { get; set; } = new List<SchoolForm>();

    public virtual ICollection<SectionEnrolment> SectionEnrolments { get; set; } = new List<SectionEnrolment>();
}
