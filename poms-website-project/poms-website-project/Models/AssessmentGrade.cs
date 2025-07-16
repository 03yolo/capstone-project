using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class AssessmentGrade
{
    public int AssessmentGradeId { get; set; }

    public int LearnerId { get; set; }

    public int SubjectId { get; set; }

    public int FacultyId { get; set; }

    public int QuarterId { get; set; }

    public string AssessmentType { get; set; } = null!;

    public int AssessmentNo { get; set; }

    public decimal Score { get; set; }

    public int TotalItems { get; set; }

    public DateOnly? DateGiven { get; set; }

    public string Remarks { get; set; } = null!;

    public virtual Faculty Faculty { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;

    public virtual Quarter Quarter { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
