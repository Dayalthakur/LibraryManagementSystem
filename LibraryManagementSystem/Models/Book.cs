using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public int? CopiesLeft { get; set; }

    public int? TotalCopies { get; set; }

    public virtual ICollection<IssuedBook> IssuedBooks { get; set; } = new List<IssuedBook>();
}
