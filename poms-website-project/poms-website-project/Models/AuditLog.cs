using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class AuditLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public string? Action { get; set; }

    public string? TableName { get; set; }

    public string? RecordPk { get; set; }

    public DateTime LogTime { get; set; }
}
