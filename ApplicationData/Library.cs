using System;
using System.Collections.Generic;

namespace Backend_LeLire.ApplicationData;

public partial class Library
{
    public int LibraryId { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<LibraryBook> LibraryBooks { get; set; } = new List<LibraryBook>();

    public virtual User User { get; set; } = null!;
}
