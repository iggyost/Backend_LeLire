using System;
using System.Collections.Generic;

namespace Backend_LeLire.ApplicationData;

public partial class LibraryView
{
    public int LibraryBooksId { get; set; }

    public int LibraryId { get; set; }

    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string CoverImage { get; set; } = null!;
}
