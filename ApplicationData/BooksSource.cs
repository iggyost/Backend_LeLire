using System;
using System.Collections.Generic;

namespace Backend_LeLire.ApplicationData;

public partial class BooksSource
{
    public int BookSourceId { get; set; }

    public int BookId { get; set; }

    public string Source { get; set; } = null!;

    public int PageNum { get; set; }

    public int LanguageId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}
