using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AdminDetail? AdminDetail { get; set; }

    public virtual Faculty? Faculty { get; set; }

    public virtual Learner? Learner { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual Parent? Parent { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SchoolForm> SchoolForms { get; set; } = new List<SchoolForm>();
}
