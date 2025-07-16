using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class AdminDetail
{
    public int AdminId { get; set; }

    public string Position { get; set; } = null!;

    public string? Office { get; set; }

    public string? ContactNo { get; set; }

    public virtual User Admin { get; set; } = null!;
}
