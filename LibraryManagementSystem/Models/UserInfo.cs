using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<IssuedBook> IssuedBooks { get; set; } = new List<IssuedBook>();
}
