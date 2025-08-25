using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models;

public partial class IssuedBook
{
    public int Id { get; set; }

    public DateTime? IssuedDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int? Book { get; set; }

    public int? UserNo { get; set; }

    public virtual Book? BookNavigation { get; set; }

    public virtual UserInfo? UserNoNavigation { get; set; }
}
