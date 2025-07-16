using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class Parent
{
    public int ParentId { get; set; }

    public virtual ICollection<ParentLearner> ParentLearners { get; set; } = new List<ParentLearner>();

    public virtual User ParentNavigation { get; set; } = null!;
}
