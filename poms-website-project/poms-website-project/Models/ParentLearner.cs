using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class ParentLearner
{
    public int ParentId { get; set; }

    public int LearnerId { get; set; }

    public string? Relationship { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Parent Parent { get; set; } = null!;
}
