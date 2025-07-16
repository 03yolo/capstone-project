using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class SchoolForm
{
    public int FormId { get; set; }

    public int LearnerId { get; set; }

    public string FormType { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int GeneratedBy { get; set; }

    public DateTime GeneratedAt { get; set; }

    public virtual User GeneratedByNavigation { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
