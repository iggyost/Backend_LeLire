using System;
using System.Collections.Generic;

namespace Backend_LeLire.ApplicationData;

public partial class LibraryBook
{
    public int LibraryBooksId { get; set; }

    public int LibraryId { get; set; }

    public int BookId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Library Library { get; set; } = null!;
}
